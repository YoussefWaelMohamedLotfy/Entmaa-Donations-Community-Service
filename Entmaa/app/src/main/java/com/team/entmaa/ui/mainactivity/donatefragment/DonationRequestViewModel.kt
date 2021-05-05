package com.team.entmaa.ui.mainactivity.donatefragment

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.skydoves.sandwich.ApiResponse
import com.skydoves.sandwich.onError
import com.skydoves.sandwich.onSuccess
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.repositories.interfaces.DonationRequestsRepository
import com.team.entmaa.data.sources.remote.DonatonRequestsApi
import com.team.entmaa.di.ContribId
import com.team.entmaa.di.FakeApi
import com.team.entmaa.ui.mainactivity.Filterable
import com.team.entmaa.util.filterBySearch
import com.team.entmaa.util.filterByTags
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch


import javax.inject.Inject

@HiltViewModel
class DonationRequestViewModel @Inject
    constructor(
    @ContribId private val contribId:Int,
    @FakeApi private val api : DonatonRequestsApi
)
    : ViewModel() , Filterable {

    private val mDonationRequests = MutableLiveData<Result<List<DonationRequestDto>>>()
    val donationRequests : LiveData<Result<List<DonationRequestDto>>> = mDonationRequests

    private var activeFilters:List<TagDto> = listOf()
    private var activeSearch:String = ""

    init {
        refresh()
    }

    override fun filterByTags(tags: List<TagDto>) {
        activeFilters = tags
        refresh()
    }

    override fun filterBySearch(searchQuery: String) {
        activeSearch = searchQuery
        refresh()
    }

    fun refresh()
    {
        viewModelScope.launch {
            mDonationRequests.value = Result.InProgress
            val response = api.getDonationRequestsFeed(contribId)

            response.onSuccess {
                mDonationRequests.value = Result.Success(this.data!!
                    .filterByTags(activeFilters)
                    .filterBySearch(activeSearch))

            }.onError {
              mDonationRequests.value = Result.Error("Network Error")
            }
        }
    }
}