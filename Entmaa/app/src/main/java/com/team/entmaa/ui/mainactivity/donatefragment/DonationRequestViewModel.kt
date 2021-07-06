package com.team.entmaa.ui.mainactivity.donatefragment

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.skydoves.sandwich.ApiResponse
import com.skydoves.sandwich.onError
import com.skydoves.sandwich.onSuccess
import com.team.entmaa.data.model.dto.ApiResponseMessage
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import com.team.entmaa.di.FakeApi
import com.team.entmaa.ui.filters.Filterable
import com.team.entmaa.util.filterBySearch
import com.team.entmaa.util.filterByTags
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch


import javax.inject.Inject

@HiltViewModel
class DonationRequestViewModel @Inject
    constructor(
    private val contributor:ContributorDto,
    private val donationsApi : DonationRequestsApi
)
    : ViewModel() , Filterable {

    private val mDonationRequests = MutableLiveData<Result<List<DonationRequestDto>>>()
    val donationRequests : LiveData<Result<List<DonationRequestDto>>> = mDonationRequests

    private var activeFilters:Set<TagDto> = setOf()
    private var activeSearch:String = ""

    init {
        refresh()
    }

    override fun filterByTags(tags: Set<TagDto>) {
        activeFilters = tags
        println(activeFilters)
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
            val response = donationsApi.getDonationRequestsFeed(contributor.id)

            response.onSuccess {
                mDonationRequests.value = Result.Success(this.data!!
                    .filterByTags(activeFilters)
                    .filterBySearch(activeSearch))

            }.onError {
              mDonationRequests.value = Result.Error("Network Error")
            }
        }
    }

    suspend fun donatedMoneyToRequest(item:DonationRequestDto, moneyQuantity:Int) : ApiResponse<ApiResponseMessage>
    {
        val moneyDonation = MoneyDonationsOnRequestDto().apply {
            donatedBy = contributor
            donatedTo = item.postedBy
            this.moneyAmount = moneyQuantity
        }

        return donationsApi.donateMoneyToRequest(item.id,moneyDonation)
    }


}