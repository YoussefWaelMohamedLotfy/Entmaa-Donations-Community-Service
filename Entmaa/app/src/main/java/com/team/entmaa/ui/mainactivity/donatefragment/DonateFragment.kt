package com.team.entmaa.ui.mainactivity.donatefragment

import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import com.team.entmaa.R
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.databinding.FragmentDonateBinding
import com.team.entmaa.databinding.ItemDonationRequestBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.durationFrom
import com.team.entmaa.util.loadURL

import dagger.hilt.android.AndroidEntryPoint
import java.time.LocalDate

@AndroidEntryPoint
class DonateFragment : Fragment(R.layout.fragment_donate) {

    private val viewModel:DonationRequestViewModel by viewModels()

    lateinit var binding: FragmentDonateBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentDonateBinding.bind(requireView())

        setupDonationRequestsAdapter()
    }

    private fun setupDonationRequestsAdapter()
    {
        val adapter = BaseListAdapter<DonationRequestDto
                ,ItemDonationRequestBinding>(R.layout.item_donation_request){ item, _ ->

            postTitle.text = item.title
            postedBy.text = item.postedBy?.username
            timePosted.text = LocalDate.now().durationFrom(item.timePosted!!.toLocalDate())
            postBody.text = item.description
            //posterPhoto.loadURL(item.profilePhotoURL)
            //postPhoto.loadURL(item.postPhotoURL)
            donationProgress.max = item.moneyNeededCount!!
            donationProgress.progress = item.moneyReceivedCount!!
            currency.text = "EGP"
            moneyTarget.text = item.moneyNeededCount.toString()
            moneyCollected.text = item.moneyReceivedCount.toString()
            heartButton.text = item.reactCount.toString()
            commentsButton.text = item.comments?.size.toString()

            commentsButton.setOnClickListener {
                Toast.makeText(requireContext(),"dfd",Toast.LENGTH_SHORT).show()
            }

        }

        binding.requestsList.adapter = adapter

        viewModel.test.observe(viewLifecycleOwner){
            when(it)
            {
                is Result.InProgress -> {
                    Log.d("Loading", "setupDonationRequestsAdapter: ")
                }

                is Result.Success -> {
                    adapter.submitList(it.data)
                    Log.d("Success", "setupDonationRequestsAdapter: ")
                }
                is Result.Error -> {
                    Log.d("Error", "setupDonationRequestsAdapter: ")
                }
            }
        }
    }

}