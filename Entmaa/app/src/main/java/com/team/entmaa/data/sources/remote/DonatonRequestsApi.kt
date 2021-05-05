package com.team.entmaa.data.sources.remote

import com.skydoves.sandwich.ApiResponse
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import retrofit2.http.GET
import retrofit2.http.Path


interface DonatonRequestsApi {

    @GET("contributors/{id}/donationrequests")
    suspend fun getDonationRequestsFeed(@Path("id") contributorId:Int)
    : ApiResponse<List<DonationRequestDto>>

    @GET("organizations/{id}/donationrequests")
    suspend fun getDonationRequestsPostedByOrg(@Path("id") orgId: Int)
    : ApiResponse<List<DonationRequestDto>>

    @GET("donationrequests/{requestid}/moneydonations")
    suspend fun getMoneyDonationsOnRequest(@Path("requestid") requestId:Int)
    : ApiResponse<List<MoneyDonationsOnRequestDto>>

    @GET("donationrequests/{requestid}/itemdonations")
    suspend fun getItemDonationsOnRequest(@Path("requestid") requestId:Int)
    : ApiResponse<List<ItemDonationsOnRequestDto>>

}