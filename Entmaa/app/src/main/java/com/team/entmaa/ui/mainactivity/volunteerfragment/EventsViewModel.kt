package com.team.entmaa.ui.mainactivity.volunteerfragment

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
import com.team.entmaa.data.model.dto.posts.EventDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import com.team.entmaa.data.sources.remote.EventsApi
import com.team.entmaa.di.FakeApi
import com.team.entmaa.ui.mainactivity.Filterable
import com.team.entmaa.util.filterBySearch
import com.team.entmaa.util.filterByTags
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch


import javax.inject.Inject

@HiltViewModel
class EventsViewModel @Inject
    constructor(
    private val contributor:ContributorDto,
    private val eventsApi : EventsApi
)
    : ViewModel() , Filterable {

    private val mEvents = MutableLiveData<Result<List<EventDto>>>()
    val events : LiveData<Result<List<EventDto>>> = mEvents

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
            mEvents.value = Result.InProgress
            val response = eventsApi.getAllEvents(contributor.id)
            mEvents.value = Result.Success(response
                .filterByTags(activeFilters)
                .filterBySearch(activeSearch))
        }
    }

    fun volunteerInEvent(eventId:Int)
    {
        viewModelScope.launch {
            eventsApi.volunteerInEvent(eventId,contributor.id)
        }
    }


}