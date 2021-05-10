package com.team.entmaa.ui.authactivity.authfragment

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.TextView
import com.team.entmaa.R
import com.team.entmaa.databinding.FragmentLoginBinding
import com.team.entmaa.ui.mainactivity.MainActivity

class LoginFragment : Fragment(R.layout.fragment_login) {

    lateinit var binding: FragmentLoginBinding


    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding = FragmentLoginBinding.bind(requireView())

        binding.signUpTxt.setOnClickListener {
            val transaction = activity?.supportFragmentManager?.beginTransaction()
            transaction?.replace(R.id.authActivity, SignUpFragment())
            transaction?.commit()
        }

        binding.butLogin.setOnClickListener {

            println("aldsfjl;akjsdfsdfdsf")

            Intent(requireContext(),MainActivity::class.java)
                .also {
                    startActivity(it)
                }
        }
    }
}