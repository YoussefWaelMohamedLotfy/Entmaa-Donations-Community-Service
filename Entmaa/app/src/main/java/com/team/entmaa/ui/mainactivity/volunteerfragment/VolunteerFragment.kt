package com.team.entmaa.ui.mainactivity.volunteerfragment

import android.content.Intent
import android.content.res.ColorStateList
import android.graphics.Color
import android.os.Bundle
import android.view.View
import androidx.core.content.ContextCompat
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.fragment.app.viewModels
import androidx.lifecycle.lifecycleScope
import com.google.android.material.button.MaterialButton
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.posts.EventDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import com.team.entmaa.databinding.FragmentVolunteerBinding
import com.team.entmaa.databinding.ItemDonationRequestBinding
import com.team.entmaa.databinding.ItemEventBinding
import com.team.entmaa.ui.commentsactivity.CommentsActivity
import com.team.entmaa.ui.mainactivity.FiltersViewModel
import com.team.entmaa.ui.mainactivity.donatefragment.DonateDialog
import com.team.entmaa.ui.mainactivity.donatefragment.DonationRequestViewModel
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.durationFrom
import com.team.entmaa.util.getColorFromAttr
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import java.time.LocalDateTime
import javax.inject.Inject

@AndroidEntryPoint
class VolunteerFragment : Fragment(R.layout.fragment_volunteer) {

    private val viewModel: EventsViewModel by viewModels()
    private val filtersViewModel: FiltersViewModel by activityViewModels()

    @Inject
    lateinit var postInteractionsApi: PostInteractionsApi
    @Inject lateinit var contributor: ContributorDto

    lateinit var binding:FragmentVolunteerBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentVolunteerBinding.bind(view)

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
        val adapter = BaseListAdapter<EventDto
                , ItemEventBinding>(R.layout.item_event){ item, _ ->

            postTitle.text = item.title
            postedBy.text = item.postedBy.username
            timePosted.text = LocalDateTime.now().durationFrom(item.timePosted.toLocalDateTime())
            postBody.text = item.description
            posterPhoto.loadURL(item.postedBy.profilePhotoUrl)
            postPhoto.loadURL(item.postPhotoUrl)

            heartButton.text = item.reactCount.toString()
            commentsButton.text = item.comments.size.toString()


            volunteerButton.setOnClickListener {

            }

            commentsButton.setOnClickListener {
                Intent(requireContext(), CommentsActivity::class.java)
                    .also {
                        it.putExtra(CommentsActivity.postIdKey,item.id)
                        startActivity(it)
                    }
            }

            fun checkLoveStatus()
            {
                val loveColor = requireContext().getColorFromAttr(R.attr.colorPrimary)
                val heartColor:Int
                val heartIcon:Int

                if(item.isLovedByMe)
                {
                    heartColor = loveColor
                    heartIcon = R.drawable.ic_favorite_filled_24
                }
                else
                {
                    heartColor = Color.GRAY
                    heartIcon = R.drawable.ic_favorite_border_24
                }

                (heartButton as MaterialButton).apply {
                    text = item.reactCount.toString()
                    this.icon = ContextCompat.getDrawable(requireContext(),heartIcon)
                    this.iconTint = ColorStateList.valueOf(heartColor)
                }
            }

            checkLoveStatus()

            heartButton.setOnClickListener {
                item.isLovedByMe = !item.isLovedByMe
                if(item.isLovedByMe)
                {
                    lifecycleScope.launch {
                        postInteractionsApi.reactOnPost(item.id,contributor.id)
                    }
                    item.reactCount++
                }
                else
                {
                    lifecycleScope.launch {
                        postInteractionsApi.removeReactOnPost(item.id,contributor.id)
                    }
                    item.reactCount--
                }

                heartButton.text = item.reactCount.toString()

                checkLoveStatus()
            }

        }

        binding.requestsList.adapter = adapter

        viewModel.events.observe(viewLifecycleOwner){ result ->

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