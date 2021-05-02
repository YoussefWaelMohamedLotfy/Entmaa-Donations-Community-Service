package com.team.entmaa.data.repositories.interfaces

import androidx.lifecycle.LiveData
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.repositories.Result


interface DonationRequestsRepository {

    fun getDonationRequestsFeed(contributorId:Int) : LiveData<Result<List<DonationRequestDto>>>

    fun getDonationRequestsPostedByOrg(orgId: Int) : LiveData<Result<List<DonationRequestDto>>>

    fun getMoneyDonationsOnRequest(requestId:Int) : LiveData<Result<List<MoneyDonationsOnRequestDto>>>

    fun getItemDonationsOnRequest(requestId:Int) : LiveData<Result<List<ItemDonationsOnRequestDto>>>
}