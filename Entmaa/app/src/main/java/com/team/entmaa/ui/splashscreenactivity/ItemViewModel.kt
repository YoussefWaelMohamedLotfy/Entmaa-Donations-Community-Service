package com.team.entmaa.ui.splashscreenactivity

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel


class ItemViewModel : ViewModel() {
    private val mutableSelectedItem = MutableLiveData<Users>()
    val selectedItem: MutableLiveData<Users> get() = mutableSelectedItem

    fun selectItem(item: Users) {
        mutableSelectedItem.value = item

    }




}