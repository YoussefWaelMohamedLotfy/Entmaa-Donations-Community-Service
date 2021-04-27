package com.team.entmaa.ui.splashscreenactivity

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel


class ItemViewModel : ViewModel() {
    private val mutableSelectedItem = MutableLiveData<Join>()
    val selectedItem: MutableLiveData<Join> get() = mutableSelectedItem

    fun selectItem(item: Boolean, type:String) {
        mutableSelectedItem.value = Join(item,type)

    }



    class Join(val isJoined:Boolean=false, val type:String=""){

    }
}