package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.reportedcase.ReportedCaseDto
import retrofit2.http.Body
import retrofit2.http.POST
import retrofit2.http.Path

interface ReportCaseApi {

    @POST("contributors/{id}/reportedcases")
    suspend fun reportCase(@Path("id") contribId:Int,@Body reportedCase: ReportedCaseDto)
}