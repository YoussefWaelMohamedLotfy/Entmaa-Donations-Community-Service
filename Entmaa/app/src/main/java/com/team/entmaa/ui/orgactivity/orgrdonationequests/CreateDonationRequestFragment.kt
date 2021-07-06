package com.team.entmaa.ui.orgactivity.orgrdonationequests

import android.net.Uri
import android.os.Bundle
import android.view.View
import androidx.activity.result.contract.ActivityResultContracts
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import com.team.entmaa.data.sources.remote.TagsApi
import com.team.entmaa.databinding.FragmentCreateDonationRequestBinding
import com.team.entmaa.ui.tags.TagsAdapter
import com.team.entmaa.util.loadURL

import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject


@AndroidEntryPoint
class CreateDonationRequestFragment : Fragment(R.layout.fragment_create_donation_request)
{
    @Inject
    lateinit var donationRequestsApi: DonationRequestsApi
    @Inject
    lateinit var org:OrganizationDto

    @Inject
    lateinit var tagsApi: TagsApi

    lateinit var binding: FragmentCreateDonationRequestBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentCreateDonationRequestBinding.bind(view)


        binding.posterPhoto.loadURL(org.profilePhotoUrl)

        val adapter = TagsAdapter{ tagDto, isChecked, selectedTags ->

        }

        lifecycleScope.launch {
            adapter.submitList(tagsApi.getAllTags().toList())
        }

        binding.tagsList.adapter = adapter


        var selectedImage = ""
        val getPhoto = registerForActivityResult(ActivityResultContracts.GetContent()) { uri: Uri? ->
            uri?.let {
                binding.postImg.setImageURI(uri)
                binding.postImg.visibility = View.VISIBLE
                selectedImage = uri.toString()
            }
        }

        binding.addImage.setOnClickListener {
            getPhoto.launch("image/*")
        }

        binding.addPost.setOnClickListener {
            val request = DonationRequestDto().apply {
                postedBy = org
                title = binding.postTitle.text.toString()
                description = binding.postBody.text.toString()
                postPhotoUrl = selectedImage
                moneyNeededCount = binding.postTarget.text.toString().toIntOrNull() ?: 1
                tags = adapter.checkedFilters.toList()
            }

            lifecycleScope.launch {
                launch {
                    donationRequestsApi.createNewDonationRequest(org.id,request)
                }.join()
                Snackbar.make(binding.root,"Donation Request Posted",Snackbar.LENGTH_SHORT)
                    .show()
                findNavController().navigateUp()
            }
        }
    }
}