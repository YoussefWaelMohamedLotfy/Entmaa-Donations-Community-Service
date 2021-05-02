package com.team.entmaa.ui.mainactivity.donatefragment

import androidx.lifecycle.LiveData
import androidx.lifecycle.ViewModel
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.repositories.interfaces.DonationRequestsRepository
import dagger.hilt.android.lifecycle.HiltViewModel


import javax.inject.Inject

@HiltViewModel
class DonationRequestViewModel @Inject
    constructor(val repository : DonationRequestsRepository)
    : ViewModel() {

    val test: LiveData<Result<List<DonationRequestDto>>> = repository.getDonationRequestsFeed(1)
}