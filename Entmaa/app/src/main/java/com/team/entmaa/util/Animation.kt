package com.team.entmaa.util

import android.view.View
import android.view.animation.AnimationUtils
import androidx.interpolator.view.animation.FastOutSlowInInterpolator


fun View.playAnimation(animId:Int,animTime:Long= 500,startOffset:Long = 0)
{
    val animation = AnimationUtils.loadAnimation(context,animId).apply {
        duration = animTime
        interpolator = FastOutSlowInInterpolator()
        this.startOffset = startOffset
    }

    startAnimation(animation)
}