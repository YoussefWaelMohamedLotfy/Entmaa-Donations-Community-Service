package com.team.entmaa.ui.mainactivity.auctionfragment

import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.fragment.app.viewModels
import androidx.navigation.fragment.findNavController
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.MainNavGraphDirections
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.auction.AuctionDto
import com.team.entmaa.data.model.dto.auction.BidDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.databinding.FragmentAuctionBinding
import com.team.entmaa.databinding.ItemAuctionBinding
import com.team.entmaa.ui.filters.FiltersViewModel
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.durationFrom
import com.team.entmaa.util.hideKeyboard
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint
import java.time.LocalDateTime
import javax.inject.Inject

@AndroidEntryPoint
class AuctionFragment : Fragment(R.layout.fragment_auction) {

    private val viewModel: AuctionViewModel by viewModels()
    private val filtersViewModel: FiltersViewModel by activityViewModels()

    @Inject
    lateinit var contributor: ContributorDto

    lateinit var binding: FragmentAuctionBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentAuctionBinding.bind(view)

        setupFiltersListener()
        setupEventsAdapter()
    }


    private fun setupFiltersListener()
    {
        filtersViewModel.userTriggeredRefresh.observe(viewLifecycleOwner){
            viewModel.refresh()
        }

        filtersViewModel.appliedFilters.observe(viewLifecycleOwner)
        {
            //println("filter")
            viewModel.filterByTags(it)
        }

        filtersViewModel.appliedSearch.observe(viewLifecycleOwner)
        {
            viewModel.filterBySearch(it)
        }

    }

    private fun setupEventsAdapter()
    {
        val adapter = BaseListAdapter<AuctionDto
                , ItemAuctionBinding>(R.layout.item_auction){ item, _ ->

            postTitle.text = item.title
            postedBy.text = item.postedBy.username
            timePosted.text = LocalDateTime.now().durationFrom(item.startDate.toLocalDateTime())
            postBody.text = item.description
            posterPhoto.loadURL(item.postedBy.profilePhotoUrl)
            postPhoto.loadURL(item.itemPhotoUrl)


            highestBid.text = item.highestBid.toString()


            posterPhoto.setOnClickListener {
                findNavController().navigate(
                    MainNavGraphDirections.actionGlobalOrgProfileFragment(item.postedBy.id))
            }


            bidButton.setOnClickListener {

                val bidAmount = bidEt.text.toString().toInt()
                val bid= BidDto().apply {
                    bidBy = contributor.id
                    auctionId = item.id
                    price = bidAmount
                }

                val highestBidValue = highestBid.text.toString().toInt()

                if(bidAmount > highestBidValue)
                {
                    viewModel.bidOnAuction(bid)
                    bidEt.text.clear()
                    highestBid.text = bidAmount.toString()
                    Snackbar.make(binding.root,"Placed bid with value $bidAmount EGP",Snackbar.LENGTH_SHORT)
                        .show()

                    hideKeyboard()
                    bidEt.clearFocus()

                }
                else
                {
                    Snackbar.make(binding.root,"Please enter an amount higher than the highest bid",Snackbar.LENGTH_SHORT)
                        .show()

                    hideKeyboard()
                }

            }

        }

        binding.auctionsList.adapter = adapter

        viewModel.auctions.observe(viewLifecycleOwner){ result ->

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