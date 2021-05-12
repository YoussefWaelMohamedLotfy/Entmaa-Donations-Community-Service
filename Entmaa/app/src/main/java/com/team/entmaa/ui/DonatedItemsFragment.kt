package com.team.entmaa.ui

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import com.google.android.material.bottomsheet.BottomSheetDialog
import com.team.entmaa.R


class DonatedItemsFragment : Fragment() {
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
       val root = inflater.inflate(R.layout.fragment_donated_items, container, false)

        val add_donate_btn:Button = root.findViewById(R.id.add_donate_btn)
        add_donate_btn.setOnClickListener {
            val buttomDialog = BottomSheetDialog(this.requireContext())
            buttomDialog.setContentView(R.layout.fragment_donation_bottom_sheet)
            buttomDialog.show()
        }


        return root
    }

}