package com.team.entmaa.ui.authactivity

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import com.team.entmaa.R
import com.team.entmaa.ui.authactivity.authfragment.LoginFragment
import com.team.entmaa.ui.authactivity.authfragment.WelcomeFragment


class MainAuthActivity : AppCompatActivity() {
   lateinit var manager:FragmentManager

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main_auth)

        replaceFragment(WelcomeFragment())

    }
}
// Extension function to replace fragment
fun AppCompatActivity.replaceFragment(fragment: Fragment){
    val fragmentManager = supportFragmentManager
    val transaction = fragmentManager.beginTransaction()
    transaction.replace(R.id.authActivity,fragment)
    transaction.addToBackStack(null)
    transaction.commit()
}