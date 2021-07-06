package com.team.entmaa.ui.orgactivity.auctions

import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.MainNavGraphDirections
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.auction.AuctionDto
import com.team.entmaa.data.model.dto.auction.BidDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.AuctionApi
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import com.team.entmaa.databinding.FragmentAuctionBinding
import com.team.entmaa.databinding.ItemAuctionBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.durationFrom
import com.team.entmaa.util.hideKeyboard
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import java.time.LocalDateTime
import javax.inject.Inject

@AndroidEntryPoint
class OrgAuctionsFragment : Fragment(R.layout.fragment_auction) {


    @Inject
    lateinit var auctionApi: AuctionApi
    @Inject
    lateinit var postInteractionsApi: PostInteractionsApi
    @Inject lateinit var org: OrganizationDto

    lateinit var binding: FragmentAuctionBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentAuctionBinding.bind(view)

        setupAuctionsAdapter()
    }



    private fun setupAuctionsAdapter()
    {
        val adapter = BaseListAdapter<AuctionDto
                , ItemAuctionBinding>(R.layout.item_auction) { item, _ ->

            postTitle.text = item.title
            postedBy.text = item.postedBy.username
            timePosted.text = LocalDateTime.now().durationFrom(item.startDate.toLocalDateTime())
            postBody.text = item.description
            posterPhoto.loadURL(item.postedBy.profilePhotoUrl)
            postPhoto.loadURL(item.itemPhotoUrl)


            highestBid.text = item.highestBid.toString()


            posterPhoto.setOnClickListener {
                findNavController().navigate(
                    MainNavGraphDirections.actionGlobalOrgProfileFragment(item.postedBy.id)
                )
            }

            bidEt.visibility = View.GONE
            bidButton.text = "View bids"
        }

        binding.auctionsList.adapter = adapter

        lifecycleScope.launch {
            adapter.submitList(auctionApi.getOrgAuctions(org.id))
        }
    }
}