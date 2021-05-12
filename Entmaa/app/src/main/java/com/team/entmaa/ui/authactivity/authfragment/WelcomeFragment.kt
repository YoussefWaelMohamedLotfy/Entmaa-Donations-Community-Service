package com.team.entmaa.ui.authactivity.authfragment

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import com.team.entmaa.R
import com.team.entmaa.ui.DonatedItemsFragment
import com.team.entmaa.ui.MapsFragment
import com.team.entmaa.ui.mainactivity.MainActivity

class WelcomeFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        val root = inflater.inflate(R.layout.fragment_welcome, container, false)

        val loginButton : Button = root.findViewById(R.id.butLogin)
        loginButton.setOnClickListener {
//            val transaction = activity?.supportFragmentManager?.beginTransaction()
//            transaction?.replace(R.id.authActivity, MapsFragment())
//            transaction?.isAddToBackStackAllowed
//            transaction?.addToBackStack(null)
//            transaction?.commit()


            Intent(requireContext(), MainActivity::class.java)
                .also {
                    startActivity(it)
                }
        }

        val signUpButton:Button = root.findViewById(R.id.butRegister)
        signUpButton.setOnClickListener {
            val transaction = activity?.supportFragmentManager?.beginTransaction()
            transaction?.replace(R.id.authActivity, SignUpFragment())
            transaction?.isAddToBackStackAllowed
            transaction?.addToBackStack(null)
            transaction?.commit()
        }

        return  root
    }


}

