package com.team.entmaa.ui.mainactivity.authfragment

import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentActivity
import androidx.viewpager2.adapter.FragmentStateAdapter

class AuthAdapter(activity:FragmentActivity): FragmentStateAdapter(activity) {

    companion object{
        const val Tab_Count = 2
    }

    override fun getItemCount(): Int {
        return Tab_Count
    }

    override fun createFragment(position: Int): Fragment {
        return when(position){
            0 -> LoginFragment()
            else -> SignupFragment()
        }
    }


}
