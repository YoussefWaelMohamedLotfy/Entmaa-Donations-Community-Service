package com.team.entmaa.ui.authactivity.authfragment

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import com.team.entmaa.R

class LoginFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root =  inflater.inflate(R.layout.fragment_login, container, false)

        val signUpButtonTxt : TextView = root.findViewById(R.id.signUp_txt)
        signUpButtonTxt.setOnClickListener {
            val transaction = activity?.supportFragmentManager?.beginTransaction()
            transaction?.replace(R.id.authActivity, SignUpFragment())
            transaction?.commit()
        }

        return root
    }


}