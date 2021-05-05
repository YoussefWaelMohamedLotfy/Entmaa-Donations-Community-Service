package com.team.entmaa.data.repositories.interfaces

import androidx.lifecycle.LiveData
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.repositories.Result


interface DonationRequestsRepository {

    suspend fun getDonationRequestsFeed(contributorId:Int) : Result<List<DonationRequestDto>>

    fun getDonationRequestsPostedByOrg(orgId: Int) : Result<List<DonationRequestDto>>

    fun getMoneyDonationsOnRequest(requestId:Int) : Result<List<MoneyDonationsOnRequestDto>>

    fun getItemDonationsOnRequest(requestId:Int) : Result<List<ItemDonationsOnRequestDto>>
}