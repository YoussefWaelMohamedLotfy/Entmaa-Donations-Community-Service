package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.posts.EventDto
import retrofit2.http.*

interface EventsApi {

    @GET("contributors/{contribId}/events")
    suspend fun getAllEvents(@Path("contribId") contribId:Int) : List<EventDto>

    @POST("events/{eventId}/volunteers?contribId=12")
    suspend fun volunteerInEvent(@Path("eventId") eventId:Int, @Query("contribId") contribId: Int)

    @GET("organizations/{orgId}/events")
    suspend fun getOrgEvents(@Path("orgId") orgId:Int) : List<EventDto>

    @POST("organizations/{orgId}/events")
    suspend fun createNewEvent(@Path("orgId") orgId:Int,@Body event: EventDto)
}