package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.posts.EventDto
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path
import retrofit2.http.Query

interface EventsApi {

    @GET("contributors/{contribId}/events")
    suspend fun getAllEvents(@Path("contribId") contribId:Int) : List<EventDto>

    @POST("events/{eventId}/volunteers?contribId=12")
    suspend fun volunteerInEvent(@Path("eventId") eventId:Int, @Query("contribId") contribId: Int)


}