package com.team.entmaa.ui.orgactivity.donateditems

import android.net.Uri
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.activityViewModels
import androidx.fragment.app.viewModels
import androidx.navigation.fragment.findNavController
import com.team.entmaa.MainNavGraphDirections
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.data.sources.remote.DonatedItemsApi
import com.team.entmaa.databinding.FragmentBrowseItemsBinding
import com.team.entmaa.databinding.ItemLostFoundBinding
import com.team.entmaa.databinding.ItemOrgDonatedBinding
import com.team.entmaa.ui.filters.FiltersViewModel
import com.team.entmaa.util.*
import com.team.entmaa.util.dialPhoneNumber
import com.team.entmaa.util.getColorFromAttr
import dagger.hilt.android.AndroidEntryPoint
import java.time.LocalDateTime
import javax.inject.Inject

@AndroidEntryPoint
class BrowseItemsFragment : Fragment(R.layout.fragment_browse_items) {

    lateinit var binding: FragmentBrowseItemsBinding

    @Inject
    lateinit var donatedItemsApi:DonatedItemsApi

    private val filtersViewModel: FiltersViewModel by activityViewModels()
    private val viewModel:DonatedItemsViewModel by viewModels()

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentBrowseItemsBinding.bind(view)

        setupFiltersListener()
        setupListAdapter()

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

    private fun setupListAdapter()
    {
        val adapter = BaseListAdapter<DonatedItemDto
                , ItemOrgDonatedBinding>(R.layout.item_org_donated){ item, _ ->

            postTitle.text = item.itemName
            postedBy.text = item.donatedBy.username
            postBody.text = item.description
            posterPhoto.loadURL(item.donatedBy.profilePhotoUrl)
            postPhoto.loadURL(item.photoUrl)



//            posterPhoto.setOnClickListener {
//                findNavController().navigate(
//                    MainNavGraphDirections.actionGlobalOrgProfileFragment(item.postedBy.id))
//            }



            contactBtn.setOnClickListener {
                requireContext().dialPhoneNumber(item.donatedBy.phoneNumber)
            }

        }

        binding.donatedItemsList.adapter = adapter

        viewModel.donatedItems.observe(viewLifecycleOwner){ result ->

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