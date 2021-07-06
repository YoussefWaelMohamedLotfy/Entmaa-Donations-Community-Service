package com.team.entmaa.ui.contribdonateditems

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.hadilq.liveevent.LiveEvent
import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.DonatedItemsApi
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject

@HiltViewModel
class DonatedItemsViewModel @Inject constructor(
    private val donatedItemsApi: DonatedItemsApi,
    private val contributor: ContributorDto
) : ViewModel() {

    private val mAddedDonatedItem:LiveEvent<DonatedItemDto> = LiveEvent()
    val addedDonatedItem: LiveData<DonatedItemDto> = mAddedDonatedItem

    private val mMyDonatedItems = MutableLiveData<List<DonatedItemDto>>()
    val myDonatedItems:LiveData<List<DonatedItemDto>> =  mMyDonatedItems

    init {
        viewModelScope.launch {
            mMyDonatedItems.value = donatedItemsApi.getContributorDonatedItems(contributor.id)
        }
    }

    fun addItemForDonation(item: DonatedItemDto)
    {
        viewModelScope.launch {
            donatedItemsApi.addDonatedItem(item,contributor.id)
        }

        mAddedDonatedItem.value = item
    }

}