package com.team.entmaa.ui.orgactivity.orgevents

import android.net.Uri
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.activity.result.contract.ActivityResultContracts
import androidx.navigation.fragment.findNavController
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.R
import com.team.entmaa.databinding.FragmentCreateEventBinding


class CreateEventFragment : Fragment(R.layout.fragment_create_event) {

    lateinit var binding:FragmentCreateEventBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentCreateEventBinding.bind(view)

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
            Snackbar.make(binding.root,"Event Posted", Snackbar.LENGTH_SHORT)
                .show()
            findNavController().navigateUp()
        }
    }
}