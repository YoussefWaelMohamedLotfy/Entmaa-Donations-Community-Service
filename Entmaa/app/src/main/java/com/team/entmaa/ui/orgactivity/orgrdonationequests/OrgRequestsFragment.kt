package com.team.entmaa.ui.orgactivity.orgrdonationequests

import android.content.res.ColorStateList
import android.graphics.Color
import android.os.Bundle
import android.view.View
import androidx.core.content.ContextCompat
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.fragment.app.viewModels
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import com.google.android.material.button.MaterialButton
import com.google.android.material.snackbar.Snackbar
import com.skydoves.sandwich.onSuccess
import com.team.entmaa.MainNavGraphDirections
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import com.team.entmaa.data.sources.remote.EventsApi
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import com.team.entmaa.databinding.FragmentDonateBinding
import com.team.entmaa.databinding.ItemDonationRequestBinding
import com.team.entmaa.databinding.ItemDonationRequestOrgBinding
import com.team.entmaa.ui.filters.FiltersViewModel
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.durationFrom
import com.team.entmaa.util.getColorFromAttr
import com.team.entmaa.util.loadURL

import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import java.time.LocalDateTime
import javax.inject.Inject

@AndroidEntryPoint
class OrgRequestsFragment : Fragment(R.layout.fragment_donate) {


    @Inject
    lateinit var donationRequestsApi: DonationRequestsApi
    @Inject
    lateinit var postInteractionsApi: PostInteractionsApi
    @Inject lateinit var org: OrganizationDto

    lateinit var binding: FragmentDonateBinding


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentDonateBinding.bind(requireView())

        setupDonationRequestsAdapter()
    }

    private fun setupDonationRequestsAdapter()
    {
        val adapter = BaseListAdapter<DonationRequestDto
                , ItemDonationRequestOrgBinding>(R.layout.item_donation_request_org) { item, _ ->

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
            commentsButton.text = item.comments.size.toString()


            posterPhoto.setOnClickListener {
                findNavController().navigate(
                    MainNavGraphDirections.actionGlobalOrgProfileFragment(item.postedBy.id)
                )
            }


            commentsButton.setOnClickListener {
                findNavController().navigate(
                    MainNavGraphDirections.actionGlobalCommentsFragment(item.id)
                )
            }

        }

        binding.requestsList.adapter = adapter

        lifecycleScope.launch {
            donationRequestsApi.getDonationRequestsPostedByOrg(org.id).onSuccess {
                adapter.submitList(this.data?.filter { it.postedBy.id == org.id })
            }

        }
    }

}