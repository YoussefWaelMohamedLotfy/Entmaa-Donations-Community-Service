package com.team.entmaa.data.repositories.implementaion

import com.skydoves.sandwich.*
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.repositories.interfaces.DonationRequestsRepository
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import javax.inject.Inject

class DonationRequestsRepositoryImpl @Inject constructor(
    private val donationRequestsApi: DonationRequestsApi
) : DonationRequestsRepository
{
    override suspend fun getDonationRequestsFeed(contributorId: Int): Result<List<DonationRequestDto>> {

        return when(val response = donationRequestsApi.getDonationRequestsFeed(contributorId))
        {
            is ApiResponse.Success -> {
                Result.Success(response.data!!)
            }

            is ApiResponse.Failure.Error -> {
                Result.Error("Network Error")
            }
            else -> Result.Error("Unknown Error")
        }
    }

    override fun getDonationRequestsPostedByOrg(orgId: Int): Result<List<DonationRequestDto>> {
        TODO("Not yet implemented")
    }

    override fun getMoneyDonationsOnRequest(requestId: Int): Result<List<MoneyDonationsOnRequestDto>> {
        TODO("Not yet implemented")
    }

    override fun getItemDonationsOnRequest(requestId: Int): Result<List<ItemDonationsOnRequestDto>> {
        TODO("Not yet implemented")
    }


}