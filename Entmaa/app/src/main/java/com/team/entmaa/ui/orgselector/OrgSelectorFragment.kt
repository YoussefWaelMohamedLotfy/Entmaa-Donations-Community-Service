package com.team.entmaa.ui.orgselector

import android.os.Bundle
import android.view.MotionEvent
import android.view.View
import android.view.View.OnTouchListener
import android.widget.SearchView
import androidx.fragment.app.Fragment
import androidx.fragment.app.viewModels
import com.iammert.library.ui.multisearchviewlib.MultiSearchView
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.databinding.FragmentOrgSelectorBinding
import com.team.entmaa.databinding.ItemOrgBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint


@AndroidEntryPoint
class OrgSelectorFragment : Fragment(R.layout.fragment_org_selector) {

    val orgSelectorViewModel:OrgSelectorViewModel by viewModels({requireParentFragment()})

    lateinit var binding:FragmentOrgSelectorBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentOrgSelectorBinding.bind(view)

        binding.orgSearchBar.setOnQueryTextListener(object : SearchView.OnQueryTextListener{
            override fun onQueryTextSubmit(query: String?): Boolean {
                orgSelectorViewModel.searchOrgs(query ?: "")
                return true
            }

            override fun onQueryTextChange(newText: String?): Boolean {
                orgSelectorViewModel.searchOrgs(newText ?: "")
                return true
            }

        })


        val orgSelectionAdpater = object : BaseListAdapter<OrganizationDto,ItemOrgBinding>(R.layout.item_org)
        {
            var selectedOrg = OrganizationDto().apply { id = -1 }
            var selectedPosition = 0

            override fun ItemOrgBinding.bind(item: OrganizationDto, position: Int) {
                val isChecked = selectedOrg.id == item.id
                checkMark.visibility = if(isChecked) View.VISIBLE else View.INVISIBLE
                root.setOnClickListener {
                    orgSelectorViewModel.setSelectedOrg(item)
                    selectedOrg = item
                    notifyItemChanged(selectedPosition)
                    selectedPosition = position
                    notifyItemChanged(selectedPosition)
                }

                orgName.text = item.username
                orgPhoto.loadURL(item.profilePhotoUrl)
            }
        }

        orgSelectorViewModel.organization.observe(viewLifecycleOwner){
            orgSelectionAdpater.submitList(it)
        }

        binding.orgList.adapter = orgSelectionAdpater
    }

}