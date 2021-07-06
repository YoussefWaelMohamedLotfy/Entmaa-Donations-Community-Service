package com.team.entmaa.ui.contribdonateditems

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.viewModels
import com.google.android.material.floatingactionbutton.FloatingActionButton
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.databinding.FragmentDonatedItemsBinding
import com.team.entmaa.databinding.ItemDonateditemBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class DonatedItemsFragment : Fragment(R.layout.fragment_donated_items) {


    lateinit var binding:FragmentDonatedItemsBinding
    val donatedItemsViewModel:DonatedItemsViewModel by viewModels()

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentDonatedItemsBinding.bind(view)

        binding.addDonateBtn.setOnClickListener {
            DonatedItemDialog().show(childFragmentManager,"")
        }

        val donatedItemsAdapter = BaseListAdapter<DonatedItemDto
                ,ItemDonateditemBinding>(R.layout.item_donateditem){ item,_ ->

            itemPhoto.loadURL(item.photoUrl)
            itemName.text = item.itemName
            itemDescription.text = item.description
        }

        donatedItemsViewModel.myDonatedItems.observe(viewLifecycleOwner){
            donatedItemsAdapter.submitList(it)
        }

        donatedItemsViewModel.addedDonatedItem.observe(viewLifecycleOwner){
            donatedItemsAdapter.add(it)
        }

        binding.myDonatedItemsList.adapter = donatedItemsAdapter
    }


}