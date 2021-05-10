package com.team.entmaa.ui.mainactivity.morefragment

import android.os.Bundle
import android.view.View
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.R
import com.team.entmaa.databinding.FragmentMoreBinding

class MoreFragment : Fragment(R.layout.fragment_more) {

    lateinit var binding:FragmentMoreBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentMoreBinding.bind(view)

        binding.profileBtn.setOnClickListener {
            findNavController().navigate(MoreFragmentDirections
                .actionMoreFragmentToContributorProfileFragment())
        }

    }

}