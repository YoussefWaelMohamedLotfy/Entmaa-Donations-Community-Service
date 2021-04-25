package com.team.entmaa.ui.splashscreenactivity.splashfragment

import android.content.Intent
import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import com.team.entmaa.R
import com.team.entmaa.ui.authactivity.MainAuthActivity

class ThirdSpalshFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        // Inflate the layout for this fragment
       val root =  inflater.inflate(R.layout.fragment_third_spalsh, container, false)

       // buttonNext add onClick Listener
       /*val loginBut: Button = root.findViewById(R.id.butNext)
        loginBut.setOnClickListener {
            val intent: Intent = Intent(activity, MainAuthActivity::class.java)
            startActivity(intent)
        }*/

        return root
    }




}