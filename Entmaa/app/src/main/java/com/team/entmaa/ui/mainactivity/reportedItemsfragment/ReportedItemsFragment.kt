package com.team.entmaa.ui.mainactivity.reportedItemsfragment

import android.net.Uri
import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.fragment.app.viewModels
import androidx.navigation.fragment.findNavController
import com.team.entmaa.MainNavGraphDirections
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.databinding.FragmentReportedItemsBinding
import com.team.entmaa.databinding.ItemLostFoundBinding
import com.team.entmaa.ui.filters.FiltersViewModel
import com.team.entmaa.util.*
import dagger.hilt.android.AndroidEntryPoint
import java.time.LocalDateTime
import javax.inject.Inject


@AndroidEntryPoint
class ReportedItemsFragment : Fragment(R.layout.fragment_reported_items) {

    private val viewModel: ReportedItemsViewModel by viewModels()
    private val filtersViewModel: FiltersViewModel by activityViewModels()

    @Inject
    lateinit var contributor: ContributorDto

    lateinit var binding: FragmentReportedItemsBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentReportedItemsBinding.bind(view)

        setupFiltersListener()
        setupEventsAdapter()
    }


    fun setupFiltersListener()
    {
        filtersViewModel.userTriggeredRefresh.observe(viewLifecycleOwner){
            viewModel.refresh()
        }

        filtersViewModel.appliedFilters.observe(viewLifecycleOwner)
        {

            viewModel.filterByTags(it)
        }

        filtersViewModel.appliedSearch.observe(viewLifecycleOwner)
        {
            viewModel.filterBySearch(it)
        }

    }

    private fun setupEventsAdapter()
    {
        val adapter = BaseListAdapter<ReportedItemDto
                , ItemLostFoundBinding>(R.layout.item_lost_found){ item, _ ->

            postTitle.text = item.name
            postedBy.text = item.postedBy.username
            timePosted.text = LocalDateTime.now().durationFrom(item.timePosted.atStartOfDay())
            postBody.text = item.description
            posterPhoto.loadURL(item.postedBy.profilePhotoUrl)
            postPhoto.loadURL(item.itemPhotoUrl)

            this.location.text = item.locationDescription


            posterPhoto.setOnClickListener {
                findNavController().navigate(
                    MainNavGraphDirections.actionGlobalOrgProfileFragment(item.postedBy.id))
            }

            if(item.lostOrFound == false)
            {
                statusTag.text = getString(R.string.item_reported_found)
                statusTag.setTextColor(requireContext().getColorFromAttr(R.attr.colorPrimary))
            }
            else
            {
                statusTag.text = getString(R.string.item_reported_lost)
                statusTag.setTextColor(requireContext().getColorFromAttr(R.attr.colorSecondary))
            }

            contactBtn.setOnClickListener {
                requireContext().dialPhoneNumber(item.postedBy.phoneNumber)
            }

            mapsButton.setOnClickListener {
                val location = Uri.parse(item.mapsLocation)
                requireContext().showMap(location)
            }

        }

        binding.reportedItemsList.adapter = adapter

        viewModel.reportedItems.observe(viewLifecycleOwner){ result ->

            result.onLoading {
                filtersViewModel.setRefreshing(true)
            }
                .onSuccess {
                    adapter.submitList(it)
                    filtersViewModel.setRefreshing(false)
                }
                .onError {

                }

        }
    }

}