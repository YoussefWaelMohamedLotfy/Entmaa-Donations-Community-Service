package com.team.entmaa.ui.authactivity.authfragment

import android.content.Intent
import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import com.team.entmaa.R
import com.team.entmaa.databinding.FragmentLoginBinding
import com.team.entmaa.ui.mainactivity.MainActivity

class LoginFragment : Fragment(R.layout.fragment_login) {

    lateinit var binding:FragmentLoginBinding

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentLoginBinding.bind(requireView())

        binding.butLogin.setOnClickListener {
            Intent(requireContext(),MainActivity::class.java)
                .also { startActivity(it) }
        }
    }

}