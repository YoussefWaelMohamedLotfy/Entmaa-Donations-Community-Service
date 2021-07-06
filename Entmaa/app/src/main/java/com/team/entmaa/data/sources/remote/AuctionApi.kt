package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.auction.AuctionDto
import com.team.entmaa.data.model.dto.auction.BidDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface AuctionApi {

    @GET("auctions")
    suspend fun getAllAuctions() : List<AuctionDto>

    @POST("auctions/{auctionId}/bidders")
    suspend fun bidOnAuction(@Path("auctionId") auctionId: Int, @Body bid:BidDto)

    @GET("organizations/{orgId}/auctions")
    suspend fun getOrgAuctions(@Path("orgId") orgId:Int) : List<AuctionDto>

    @POST("organizations/{orgId}/auctions")
    suspend fun createNewAuction(@Path("orgId") orgId:Int,@Body auction: AuctionDto)
}