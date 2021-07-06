package com.team.entmaa.ui.orgactivity.dashboard


import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import com.skydoves.sandwich.getOrNull
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import com.team.entmaa.databinding.FragmentOrgDashBinding
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject

@AndroidEntryPoint
class OrgDashFragment : Fragment(R.layout.fragment_org_dash) {

    lateinit var binding:FragmentOrgDashBinding

    @Inject
    lateinit var org:OrganizationDto

    @Inject
    lateinit var donationRequestsApi: DonationRequestsApi

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentOrgDashBinding.bind(view)

        binding.orgName.text = org.username

        binding.newEvenBtn.setOnClickListener {
            findNavController().navigate(OrgDashFragmentDirections.actionOrgDashFragmentToCreateEventFragment())
        }

        binding.newAuctionBtn.setOnClickListener {
            findNavController().navigate(OrgDashFragmentDirections.actionOrgDashFragmentToCreateAuctionFragment())
        }

        binding.newDonationReqBtn.setOnClickListener {
            findNavController().navigate(OrgDashFragmentDirections.actionOrgDashFragmentToCreateDonationRequsetFragment())
        }

        binding.profileBtn.setOnClickListener {

        }

        binding.orgRequestsBtn.setOnClickListener {
            findNavController().navigate(OrgDashFragmentDirections.actionOrgDashFragmentToOrgRequestsFragment())
        }

        lifecycleScope.launch {
            val list = donationRequestsApi.getDonationRequestsPostedByOrg(1).getOrNull()
            binding.donationRequestsCount.text = list?.filter { it.postedBy.id == org.id }?.size.toString()
        }


        binding.logoutBtn.setOnClickListener {
            requireActivity().finish()
        }
    }
}