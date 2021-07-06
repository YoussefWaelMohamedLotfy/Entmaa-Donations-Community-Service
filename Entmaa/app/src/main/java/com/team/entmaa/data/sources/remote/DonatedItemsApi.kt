package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface DonatedItemsApi {

    @POST("contributors/{id}/donateditems")
    suspend fun addDonatedItem(@Body donatedItemDto: DonatedItemDto, @Path("id") contribId:Int)

    @GET("donateditems")
    suspend fun getAllDonatedItemS() : List<DonatedItemDto>

    @GET("contributors/{id}/donateditems")
    suspend fun getContributorDonatedItems(@Path("id") contribId:Int) : List<DonatedItemDto>

    @GET("organizations/:id/donateditems")
    suspend fun getOrgReceivedDonatedItems(@Path("id") orgId:Int) : List<DonatedItemDto>

}