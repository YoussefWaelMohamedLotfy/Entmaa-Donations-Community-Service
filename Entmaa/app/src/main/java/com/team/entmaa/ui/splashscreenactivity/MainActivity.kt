package com.team.entmaa.ui.splashscreenactivity

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.ImageView
import androidx.annotation.NonNull
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import androidx.fragment.app.FragmentPagerAdapter
import androidx.fragment.app.FragmentStatePagerAdapter
import androidx.viewpager.widget.ViewPager
import androidx.viewpager2.adapter.FragmentStateAdapter
import androidx.viewpager2.widget.ViewPager2
import com.team.entmaa.R
import com.team.entmaa.ui.splashscreenactivity.splashfragment.*

class MainActivity : AppCompatActivity() {

    /*lateinit var imgbg: ImageView
    lateinit var imglogo: ImageView
    lateinit var imgname: ImageView
    lateinit var lottie: LottieAnimationView*/
    private val NUM_PAGES: Int = 3
    private lateinit var viewPager:ViewPager
    private lateinit var pagerAdapter:ScreensSlideAdapter

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_splash)

        window.decorView.systemUiVisibility = View.SYSTEM_UI_FLAG_FULLSCREEN
        actionBar?.hide()


        /*imgbg = findViewById(R.id.imgbg);
        imglogo = findViewById(R.id.imglogo);
        imgname = findViewById(R.id.imgname);
        lottie = findViewById(R.id.lottie);*/
        viewPager =  findViewById(R.id.pager)
        pagerAdapter  = ScreensSlideAdapter(supportFragmentManager)
        viewPager.adapter = pagerAdapter


        /*imgbg.animate().translationY(-2500F).setDuration(1500).startDelay = 4000
        imglogo.animate().translationY(2000F).setDuration(1500).startDelay = 4000
        imgname.animate().translationY(2000F).setDuration(1500).startDelay = 4000
        lottie.animate().translationY(2000F).setDuration(1500).startDelay = 4000*/



    }

    private class ScreensSlideAdapter(@NonNull manager: FragmentManager) :
        FragmentStatePagerAdapter(manager) {

        /**
         * Return the number of views available.
         */
        override fun getCount(): Int {
            return 3
        }

        /**
         * Return the Fragment associated with a specified position.
         */
        override fun getItem(position: Int): Fragment {
            when (position) {
                0 -> return FirstSpalshFragment()
                1 -> return SecondSpalshFragment()
            }
            return ThirdSpalshFragment()
        }
    }


}


