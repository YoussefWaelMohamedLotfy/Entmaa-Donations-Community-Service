package com.team.entmaa.ui.mainactivity

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.viewpager2.widget.ViewPager2
import com.google.android.material.floatingactionbutton.FloatingActionButton
import com.google.android.material.tabs.TabLayout
import com.google.android.material.tabs.TabLayoutMediator
import com.team.entmaa.R
import com.team.entmaa.ui.mainactivity.authfragment.AuthAdapter

class AuthAcitivity : AppCompatActivity() {


    private lateinit var tabLayout: TabLayout
    private lateinit var viewPager: ViewPager2
    private lateinit var floatBut: FloatingActionButton

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.acitivity_auth)


        //  Auth UI includes the tabs SignUp & Login

        tabLayout = findViewById(R.id.tapLayout);
        viewPager = findViewById(R.id.viewpager);
        floatBut  = findViewById(R.id.googleActionButton);


         val adapter = AuthAdapter(this)
         //viewPager.orientation = ViewPager2.ORIENTATION_HORIZONTAL
         viewPager.adapter = adapter
         TabLayoutMediator(tabLayout, viewPager) { tab, position ->
             when (position) {
                 0 -> tab.text = "Login"
                 else -> tab.text = "SignUp"
             }
         }.attach() //this replaces the tabLayout.setupWithViewPager() from ViewPager API*/
    }
}