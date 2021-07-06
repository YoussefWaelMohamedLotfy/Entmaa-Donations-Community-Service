package com.team.entmaa.data.sources.remote

import com.team.entmaa.data.model.dto.users.OrganizationDto
import retrofit2.http.GET

interface OrganizationApi {

    @GET("organizations")
    fun getAllOrganizations() : List<OrganizationDto>
}