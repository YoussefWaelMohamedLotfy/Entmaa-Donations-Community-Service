package com.team.entmaa.ui.customviews

import android.content.Context
import android.content.res.ColorStateList
import android.graphics.Color
import android.util.AttributeSet
import android.view.LayoutInflater
import android.widget.LinearLayout
import androidx.core.content.withStyledAttributes
import com.google.android.material.card.MaterialCardView
import com.google.android.material.shape.CornerFamily
import com.google.android.material.shape.ShapeAppearanceModel
import com.team.entmaa.R
import com.team.entmaa.databinding.ViewDashCardBinding
import com.team.entmaa.util.dpToPixel

class DashCardView(context:Context,attributeSet:AttributeSet) :
    MaterialCardView(context,attributeSet) {

    val binding:ViewDashCardBinding

    init {

        val inflater = LayoutInflater.from(context)
        val view = inflater.inflate(R.layout.view_dash_card,this,false)

        binding = ViewDashCardBinding.bind(view)

        context.withStyledAttributes(attributeSet, R.styleable.DashCardView) {
            binding.icon.apply {
                setImageDrawable(getDrawable(R.styleable.DashCardView_icon))
                val defaultSize = 40.dpf
                val size = getDimension(R.styleable.DashCardView_iconSize,defaultSize)
                layoutParams.apply {
                    width = size.toInt()
                    height = size.toInt()
                }
                requestLayout()
            }

            binding.label.text = getString(R.styleable.DashCardView_text)

        }

        isClickable = true
        isFocusable = true

        val size = 12.dpf
        shapeAppearanceModel = ShapeAppearanceModel.builder()
            .setAllCorners(CornerFamily.ROUNDED,size)
            .build()

        elevation = 8.dpf

        strokeWidth = 1.dp
        setStrokeColor(context.getColorStateList(R.color.color_on_surface_alpha_10))

        //minimumHeight = 150.dp


        addView(view)
    }


    val Int.dpf : Float
        get() = context.dpToPixel(this).toFloat()

    val Int.dp : Int
        get() = context.dpToPixel(this)


}