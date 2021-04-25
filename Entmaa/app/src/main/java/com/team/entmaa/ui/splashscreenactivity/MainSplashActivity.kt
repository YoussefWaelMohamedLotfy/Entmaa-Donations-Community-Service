package com.team.entmaa.ui.splashscreenactivity

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import androidx.annotation.NonNull
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import androidx.fragment.app.FragmentStatePagerAdapter
import com.cuberto.liquid_swipe.LiquidPager
import com.team.entmaa.R
import com.team.entmaa.ui.splashscreenactivity.splashfragment.*

class MainSplashActivity : AppCompatActivity() {


    private val NUM_PAGES: Int = 3
    private lateinit var viewPager:LiquidPager
    private lateinit var pagerAdapter:ScreensSlideAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main_splash)

        window.decorView.systemUiVisibility = View.SYSTEM_UI_FLAG_FULLSCREEN
        actionBar?.hide()


        viewPager = findViewById(R.id.pager)

        pagerAdapter  = ScreensSlideAdapter(supportFragmentManager)
        viewPager.adapter = pagerAdapter

    }


    override fun onBackPressed() {

        if (viewPager.currentItem > 0)
        {
            viewPager.switchPage(-1)
            return
        }

        super.onBackPressed()
    }

    private class ScreensSlideAdapter(@NonNull manager: FragmentManager) :
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


}


