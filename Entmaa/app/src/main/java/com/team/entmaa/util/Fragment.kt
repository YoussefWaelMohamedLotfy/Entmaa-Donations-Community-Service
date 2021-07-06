package com.team.entmaa.util

import android.app.Activity
import android.view.View
import android.view.inputmethod.InputMethodManager
import androidx.fragment.app.Fragment


fun Fragment.hideKeyboard()
{
    val imm: InputMethodManager = requireActivity()
        .getSystemService(Activity.INPUT_METHOD_SERVICE) as InputMethodManager

    val token = requireActivity().currentFocus?.windowToken
    // hide the keyboard
    imm.hideSoftInputFromWindow(token, 0)
}