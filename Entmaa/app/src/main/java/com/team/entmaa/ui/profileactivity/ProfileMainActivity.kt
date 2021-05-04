package com.team.entmaa.ui.profileactivity

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import com.team.entmaa.R
import com.team.entmaa.ui.authactivity.authfragment.WelcomeFragment

class ProfileMainActivity : AppCompatActivity() {
    var manager: FragmentManager = supportFragmentManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_profile_main)
        replaceFragment(ProfileFragment(),manager)
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

fun replaceFragment(fragment: Fragment, manager:FragmentManager){
    val transaction = manager.beginTransaction()
    transaction.replace(R.id.profileActivity, fragment)
    transaction.commit()
}

