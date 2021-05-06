package com.team.entmaa.ui.mainactivity.donatefragment

import android.content.Intent
import android.graphics.Color
import android.graphics.drawable.VectorDrawable
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Toast
import androidx.core.content.ContextCompat
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.fragment.app.viewModels
import com.google.android.material.button.MaterialButton
import com.team.entmaa.R
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.databinding.FragmentDonateBinding
import com.team.entmaa.databinding.ItemDonationRequestBinding
import com.team.entmaa.ui.commentsactivity.CommentsActivity
import com.team.entmaa.ui.mainactivity.FiltersViewModel
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.durationFrom
import com.team.entmaa.util.getColorFromAttr
import com.team.entmaa.util.loadURL

import dagger.hilt.android.AndroidEntryPoint
import java.time.LocalDate
import java.time.LocalDateTime

@AndroidEntryPoint
class DonateFragment : Fragment(R.layout.fragment_donate) {

    private val viewModel:DonationRequestViewModel by viewModels()
    private val filtersViewModel:FiltersViewModel by activityViewModels()

    lateinit var binding: FragmentDonateBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentDonateBinding.bind(requireView())

        setupDonationRequestsAdapter()
        setupFiltersListener()
    }

    private fun setupFiltersListener()
    {
        filtersViewModel.refreshState.observe(viewLifecycleOwner){ isRefreshing ->
            if(isRefreshing)
            {
                viewModel.refresh()
            }
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

    private fun setupDonationRequestsAdapter()
    {
        val adapter = BaseListAdapter<DonationRequestDto
                ,ItemDonationRequestBinding>(R.layout.item_donation_request){ item, _ ->

            postTitle.text = item.title
            postedBy.text = item.postedBy.username
            timePosted.text = LocalDateTime.now().durationFrom(item.timePosted.toLocalDateTime())
            postBody.text = item.description
            posterPhoto.loadURL(item.postedBy.profilePhotoUrl)
            postPhoto.loadURL(item.postPhotoUrl)
            donationProgress.max = item.moneyNeededCount
            donationProgress.progress = item.moneyReceivedCount
            currency.text = "EGP"
            moneyTarget.text = item.moneyNeededCount.toString()
            moneyCollected.text = item.moneyReceivedCount.toString()
            heartButton.text = item.reactCount.toString()
            commentsButton.text = item.comments.size.toString()


            commentsButton.setOnClickListener {
                Intent(requireContext(),CommentsActivity::class.java)
                    .also {
                        startActivity(it)
                    }
            }

            val loveColor = requireContext().getColorFromAttr(R.attr.colorPrimary)

            if(item.isLovedByMe)
            {
                (heartButton as MaterialButton).icon =
                    ContextCompat.getDrawable(requireContext(),R.drawable.ic_favorite_filled_24)

                (heartButton as MaterialButton).icon.setTint(loveColor)
            }

            heartButton.setOnClickListener {
                item.isLovedByMe = !item.isLovedByMe
                var color:Int
                var icon:Int

                if(item.isLovedByMe)
                {
                    item.reactCount++
                    color = loveColor
                    icon = R.drawable.ic_favorite_filled_24
                }
                else
                {
                    item.reactCount--
                    color = Color.GRAY
                    icon = R.drawable.ic_favorite_border_24
                }


                (heartButton as MaterialButton).icon =
                    ContextCompat.getDrawable(requireContext(),icon)

                heartButton.icon.setTint(color)

                heartButton.text = item.reactCount.toString()
            }

        }

        binding.requestsList.adapter = adapter

        viewModel.donationRequests.observe(viewLifecycleOwner){ result ->

            result.onLoading {
                if(!filtersViewModel.refreshState.value!!)
                {
                    filtersViewModel.setRefreshing(true)
                }
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