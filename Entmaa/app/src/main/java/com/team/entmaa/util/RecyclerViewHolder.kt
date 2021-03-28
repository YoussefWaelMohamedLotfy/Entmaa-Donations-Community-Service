package com.team.entmaa.util

import android.view.ViewGroup

interface BindableViewHolder <in T> {

    fun bind(item: T)
}

interface ViewHolderCreator<out T> {

    fun from(parent: ViewGroup) : T
}