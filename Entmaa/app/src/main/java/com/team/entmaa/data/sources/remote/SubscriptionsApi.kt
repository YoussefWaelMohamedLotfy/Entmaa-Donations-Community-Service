package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.subscriptions.SubscriptionDto
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface SubscriptionsApi {

    @POST("contributors/{id}/subscriptions")
    suspend fun addNewSubscription(@Path("id") contribId:Int,@Body subscription:SubscriptionDto)

    @GET("contributors/{id}/subscriptions")
    suspend fun getContributorSubscriptions(@Path("id") contribId:Int) : List<SubscriptionDto>

}