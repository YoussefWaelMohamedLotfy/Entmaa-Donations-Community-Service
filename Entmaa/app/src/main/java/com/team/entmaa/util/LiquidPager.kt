package com.team.entmaa.util

import com.cuberto.liquid_swipe.LiquidPager

fun LiquidPager.swipeBack() {

    if (!isFakeDragging)
    {
        beginFakeDrag()
    }
    val swipeByPixels = context.dpToPixel(900).toFloat()

    fakeDragBy(swipeByPixels)

    endFakeDrag()
}