package com.team.entmaa.ui.authactivity

import android.os.Bundle
import android.util.Log
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import com.team.entmaa.R
import com.team.entmaa.ui.authactivity.authfragment.WelcomeFragment


class MainAuthActivity : AppCompatActivity() {
    var manager:FragmentManager = supportFragmentManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main_auth)

        /** Check userType **/
        val userType = intent.getStringExtra("EXTRA_USER_TYPE")
        if (userType != null) {
            Log.i("UserType",userType)
        }

        replaceFragment(WelcomeFragment(),manager)

    }

    override fun onBackPressed() {

        if (manager.backStackEntryCount > 0) {
            Log.i("MainActivity", "popping backstack")
            manager.popBackStack()
        } else {
            Log.i("MainActivity", "nothing on backstack, calling super")
            super.onBackPressed()
        }
    }
}

fun replaceFragment(fragment: Fragment,manager:FragmentManager){
    val transaction = manager.beginTransaction()
    transaction.replace(R.id.authActivity, fragment)
    transaction.commit()
}