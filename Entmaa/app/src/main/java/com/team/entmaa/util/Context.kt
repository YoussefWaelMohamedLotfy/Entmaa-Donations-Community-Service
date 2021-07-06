package com.team.entmaa.util

import android.content.Context
import android.content.Intent
import android.net.Uri
import android.util.TypedValue
import androidx.annotation.AttrRes
import androidx.annotation.ColorInt

fun Context.dpToPixel(dp: Int) : Int
{
    val density: Float = resources.displayMetrics.density
    return (dp * density).toInt()
}


@ColorInt
fun Context.getColorFromAttr(
    @AttrRes attrColor: Int,
    typedValue: TypedValue = TypedValue(),
    resolveRefs: Boolean = true
): Int {
    theme.resolveAttribute(attrColor, typedValue, resolveRefs)
    return typedValue.data
}


fun Context.dialPhoneNumber(phoneNumber: String) {
    val intent = Intent(Intent.ACTION_DIAL).apply {
        data = Uri.parse("tel:$phoneNumber")
    }
    if (intent.resolveActivity(packageManager) != null) {
        startActivity(intent)
    }
    else
    {
        println("Failed")
    }
}

fun Context.showMap(geoLocation: Uri) {
    val intent = Intent(Intent.ACTION_VIEW).apply {
        data = geoLocation
    }
    if (intent.resolveActivity(packageManager) != null) {
        startActivity(intent)
    }
}