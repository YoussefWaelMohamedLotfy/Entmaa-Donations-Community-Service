package com.team.entmaa.ui.splashscreenactivity.splashfragment

import androidx.annotation.NonNull
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import androidx.fragment.app.FragmentStatePagerAdapter

class ScreensSlideAdapter(@NonNull manager: FragmentManager) :
    FragmentStatePagerAdapter(manager) {

    /**
     * Return the number of views available.
     */
    override fun getCount(): Int {
        return 5
    }

    /**
     * Return the Fragment associated with a specified position.
     */
    override fun getItem(position: Int): Fragment {
        when (position) {
            0 -> return FirstSpalshFragment()
            1 -> return SecondSpalshFragment()
            2-> return ThirdSpalshFragment()
            3-> return JoinAsOrgFragment()
        }
        return JoinAsUserFragment()
    }
}
