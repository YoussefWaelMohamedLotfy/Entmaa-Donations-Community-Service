package com.team.entmaa.ui.splashscreenactivity

import android.content.Intent
import android.content.SharedPreferences
import android.os.Bundle
import android.util.Log
import android.view.View
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.lifecycle.Observer
import com.cuberto.liquid_swipe.LiquidPager
import com.team.entmaa.R
import com.team.entmaa.ui.authactivity.MainAuthActivity
import com.team.entmaa.ui.splashscreenactivity.splashfragment.ScreensSlideAdapter

class MainSplashActivity : AppCompatActivity() {


    private lateinit var viewPager:LiquidPager
    private lateinit var pagerAdapter:ScreensSlideAdapter
    lateinit var settings: SharedPreferences
    private val viewModel: ItemViewModel by viewModels()
    private val  PREFS_NAME = "MyPrefsFile"


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main_splash)

        checkSharedPreferences()

        /** observe onClick **/
        viewModel.selectedItem.observe(this) { item ->
            // Perform an action with the latest item data

            Log.i("onCreate", item.toString())
           setSharedPreferences()
        }

        /** Removing the title bar and navigation bar **/
        window.decorView.systemUiVisibility = View.SYSTEM_UI_FLAG_FULLSCREEN
        actionBar?.hide()

        viewPager = findViewById(R.id.pager)

        pagerAdapter  = ScreensSlideAdapter(supportFragmentManager)
        viewPager.adapter = pagerAdapter


    }

    /**override the behaviour of pressing back button**/
    override fun onBackPressed() {

        if (viewPager.currentItem > 0)
        {
            viewPager.switchPage(-1)
            return
        }

        super.onBackPressed()
    }

   fun setSharedPreferences() {
       Log.i("setSharedPreferences", "Called")
       settings.edit().putBoolean("my_first_time", false).commit();
       val intent: Intent = Intent(this, MainAuthActivity::class.java)
       startActivity(intent)
       finish()
   }

    private fun checkSharedPreferences(){
        Log.i("checkSharedPreferences", "Called")
        settings = getSharedPreferences(PREFS_NAME, 0)
        if (settings.getBoolean("my_first_time", true)) {
            Log.i("Comments", "First time");

        }else{
            Log.i("Comments", "Second time");
            val intent: Intent = Intent(this, MainAuthActivity::class.java)
            startActivity(intent)
            finish()

        }
    }
}


