package com.team.entmaa.ui.authactivity.authfragment

import android.content.Intent
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.fragment.app.Fragment
import com.team.entmaa.R
import com.team.entmaa.ui.mainactivity.MainActivity

class LoginFragment : Fragment(){
    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        val rootView = inflater.inflate(R.layout.fragment_login, container, false)

        //Currently will redirect to the mainPage
        val loginBut: Button = rootView.findViewById(R.id.login_button)
        loginBut.setOnClickListener {
            val intent:Intent = Intent(activity,MainActivity::class.java)
            startActivity(intent)
        }
        return rootView
    }

}