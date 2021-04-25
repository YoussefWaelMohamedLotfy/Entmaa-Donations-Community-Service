package com.team.entmaa.util

import android.content.Context

fun Context.dpToPixel(dp: Int) : Int
{
    val density: Float = resources.displayMetrics.density
    return (dp * density).toInt()
}