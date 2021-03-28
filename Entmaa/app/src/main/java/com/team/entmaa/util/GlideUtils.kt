package com.team.entmaa.util

import android.widget.ImageView
import com.bumptech.glide.Glide

fun ImageView.loadURL(url:String)
{
    Glide.with(this)
        .load(url)
        .into(this)
}