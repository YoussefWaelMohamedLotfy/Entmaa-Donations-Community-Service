package com.team.entmaa.ui.mainactivity.donatefragment

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.team.entmaa.data.model.domain.DonationRequest
import com.team.entmaa.data.repositories.IRepository
import com.team.entmaa.di.FakeRepository
import dagger.hilt.android.lifecycle.HiltViewModel
import javax.inject.Inject

@HiltViewModel
class DonationRequestViewModel @Inject
    constructor(@FakeRepository private val repository:IRepository)
    : ViewModel() {

    private val mRequestsList = MutableLiveData<List<DonationRequest>>()
    val requestsList: LiveData<List<DonationRequest>> = mRequestsList

    init {
        mRequestsList.value = repository.getDonationRequests()
    }
}