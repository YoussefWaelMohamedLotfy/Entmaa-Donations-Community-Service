package com.team.entmaa.ui.authactivity.authfragment

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import com.team.entmaa.R

class SignUpFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root =  inflater.inflate(R.layout.fragment_sign_up, container, false)

        val loginButtonTxt : TextView = root.findViewById(R.id.login_txt)
        loginButtonTxt.setOnClickListener {
            val transaction = activity?.supportFragmentManager?.beginTransaction()
            transaction?.replace(R.id.authActivity, LoginFragment())
            transaction?.commit()
        }


        val signUpButton : TextView = root.findViewById(R.id.SignUp_btn)
        signUpButton.setOnClickListener {
            val transaction = activity?.supportFragmentManager?.beginTransaction()
            transaction?.replace(R.id.authActivity, UserInfoFragment())
            transaction?.isAddToBackStackAllowed
            transaction?.addToBackStack(null)
            transaction?.commit()
        }

        return  root
    }

}