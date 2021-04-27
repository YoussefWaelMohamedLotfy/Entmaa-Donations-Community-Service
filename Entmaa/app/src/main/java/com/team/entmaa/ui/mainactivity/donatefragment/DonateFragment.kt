package com.team.entmaa.ui.mainactivity.donatefragment

import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import com.team.entmaa.R
import com.team.entmaa.databinding.FragmentDonateBinding

import dagger.hilt.android.AndroidEntryPoint

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
        val adapter = DonationRequestsAdapter()
        binding.requestsList.adapter = adapter

        viewModel.requestsList.observe(viewLifecycleOwner){
            adapter.submitList(it)
        }
    }

}