package com.team.entmaa.ui.donationreminders

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.hadilq.liveevent.LiveEvent
import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.data.model.dto.subscriptions.SubscriptionDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.SubscriptionsApi
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject

@HiltViewModel
class RemindersViewModel @Inject constructor(
    private val subscriptionsApi: SubscriptionsApi,
    private val contributor: ContributorDto
) : ViewModel() {

    private val mAddedSubscription:LiveEvent<SubscriptionDto> = LiveEvent()
    val addedSubscription: LiveData<SubscriptionDto> = mAddedSubscription

    private val mMySubscriptions = MutableLiveData<List<SubscriptionDto>>()
    val mySubscriptions:LiveData<List<SubscriptionDto>> =  mMySubscriptions

    init {
        viewModelScope.launch {
            mMySubscriptions.value = subscriptionsApi.getContributorSubscriptions(contributor.id)
        }
    }

    fun addNewSubscription(subscription: SubscriptionDto)
    {
        viewModelScope.launch {
            subscriptionsApi.addNewSubscription(contributor.id,subscription)
        }

        mAddedSubscription.value = subscription
    }

}