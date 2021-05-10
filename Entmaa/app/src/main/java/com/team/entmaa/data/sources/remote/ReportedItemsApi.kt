package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import retrofit2.http.GET

interface ReportedItemsApi {

    @GET("/reporteditems")
    suspend fun getAllReportedItems() : List<ReportedItemDto>

}