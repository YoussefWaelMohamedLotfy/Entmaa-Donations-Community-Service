package com.team.entmaa.data.repositories.implementaion

import androidx.lifecycle.LiveData
import androidx.lifecycle.liveData
import com.skydoves.sandwich.*
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.repositories.interfaces.DonationRequestsRepository
import com.team.entmaa.data.sources.remote.DonatonRequestsApi
import javax.inject.Inject

class DonationRequestsRepositoryImpl @Inject constructor(
    private val donationRequestsApi: DonatonRequestsApi
) : DonationRequestsRepository
{
    override fun getDonationRequestsFeed(contributorId: Int) = liveData {

        emit(Result.InProgress)

        val response = donationRequestsApi.getDonationRequestsFeed(1).getOrThrow()
        println(response)
        println(response!![0].title)
        emit(Result.Success(response!!))

    }

    override fun getDonationRequestsPostedByOrg(orgId: Int): LiveData<Result<List<DonationRequestDto>>> {
        TODO("Not yet implemented")
    }

    override fun getMoneyDonationsOnRequest(requestId: Int): LiveData<Result<List<MoneyDonationsOnRequestDto>>> {
        TODO("Not yet implemented")
    }

    override fun getItemDonationsOnRequest(requestId: Int): LiveData<Result<List<ItemDonationsOnRequestDto>>> {
        TODO("Not yet implemented")
    }


}