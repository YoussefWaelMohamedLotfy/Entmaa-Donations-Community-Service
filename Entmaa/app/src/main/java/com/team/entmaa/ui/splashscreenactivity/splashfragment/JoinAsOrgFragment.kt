package com.team.entmaa.ui.splashscreenactivity.splashfragment

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.fragment.app.activityViewModels
import com.team.entmaa.R
import com.team.entmaa.ui.splashscreenactivity.ItemViewModel
import com.team.entmaa.ui.splashscreenactivity.Users


class JoinAsOrgFragment : Fragment() {
    private val viewModel: ItemViewModel by activityViewModels()
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root =  inflater.inflate(R.layout.fragment_join_as_org, container, false)
        val joinButton:Button = root.findViewById(R.id.butJoin)

        joinButton.setOnClickListener {
            onItemClicked(Users.Organization)

        }
        return root
    }

    fun onItemClicked(item:Users) {
        // Set a new item
        viewModel.selectItem(item)
    }

}