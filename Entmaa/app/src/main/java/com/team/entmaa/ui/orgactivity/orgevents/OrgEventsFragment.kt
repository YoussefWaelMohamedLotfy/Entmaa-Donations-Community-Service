package com.team.entmaa.ui.orgactivity.orgevents

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
import com.team.entmaa.MainNavGraphDirections
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.EventDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.repositories.onError
import com.team.entmaa.data.repositories.onLoading
import com.team.entmaa.data.repositories.onSuccess
import com.team.entmaa.data.sources.remote.EventsApi
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import com.team.entmaa.databinding.FragmentVolunteerBinding
import com.team.entmaa.databinding.ItemEventBinding
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
class OrgEventsFragment : Fragment(R.layout.fragment_volunteer) {

    @Inject
    lateinit var eventsApi: EventsApi
    @Inject
    lateinit var postInteractionsApi: PostInteractionsApi
    @Inject lateinit var org: OrganizationDto

    lateinit var binding:FragmentVolunteerBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentVolunteerBinding.bind(view)

        setupEventsAdapter()
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


            volunteerButton.text = "Volunteers"

//            posterPhoto.setOnClickListener {
//                findNavController().navigate(
//                    MainNavGraphDirections.actionGlobalOrgProfileFragment(item.postedBy.id))
//            }
//
//            commentsButton.setOnClickListener {
//                findNavController().navigate(
//                    MainNavGraphDirections.actionGlobalCommentsFragment(item.id))
//            }
//
//            detailsButton.setOnClickListener {
//                findNavController().navigate(VolunteerFragmentDirections.actionVolunteerFragmentToEventDetailsFragment())
//            }

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
                        postInteractionsApi.reactOnPost(item.id,org.id)
                    }
                    item.reactCount++
                }
                else
                {
                    lifecycleScope.launch {
                        postInteractionsApi.removeReactOnPost(item.id,org.id)
                    }
                    item.reactCount--
                }

                heartButton.text = item.reactCount.toString()

                checkLoveStatus()
            }

        }

        binding.eventsList.adapter = adapter

        lifecycleScope.launch {

            adapter.submitList(eventsApi.getOrgEvents(org.id))
        }
    }

}