package com.team.entmaa.ui.authactivity.authfragment

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.fragment.app.Fragment
import com.team.entmaa.R
import com.team.entmaa.ui.DataActivity

class SignupFragment:Fragment() {
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val rootView = inflater.inflate(R.layout.signup_fragment, container, false)

        //Currently will redirect to the mainPage
        val loginBut: Button = rootView.findViewById(R.id.signup_button)
        loginBut.setOnClickListener {
            val intent: Intent = Intent(activity, DataActivity::class.java)
            startActivity(intent)
        }
        return rootView
    }


}