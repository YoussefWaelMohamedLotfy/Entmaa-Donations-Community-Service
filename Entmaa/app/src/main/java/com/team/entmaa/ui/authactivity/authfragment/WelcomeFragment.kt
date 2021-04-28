package com.team.entmaa.ui.authactivity.authfragment

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.SharedElementCallback
import com.team.entmaa.R
import com.team.entmaa.ui.authactivity.replaceFragment

class WelcomeFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root = inflater.inflate(R.layout.fragment_welcome, container, false)

        val loginButton : Button = root.findViewById(R.id.butLogin)
        loginButton.setOnClickListener {
            val transaction = activity?.supportFragmentManager?.beginTransaction()
            transaction?.replace(R.id.authActivity, LoginFragment())
            transaction?.isAddToBackStackAllowed
            transaction?.addToBackStack(null)
            transaction?.commit()
        }

        return  root;
    }


}

