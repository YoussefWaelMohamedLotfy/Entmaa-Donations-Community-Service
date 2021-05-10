package com.team.entmaa.data.sources.remote

import com.skydoves.sandwich.ApiResponse
import com.team.entmaa.data.model.dto.tags.TagDto
import retrofit2.http.GET

interface TagsApi {

    @GET("tags")
    suspend fun getAllTags() : Set<TagDto>

}