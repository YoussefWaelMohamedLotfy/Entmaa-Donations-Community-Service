package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.ReportedItemsApi
import kotlinx.coroutines.delay
import kotlin.random.Random

object ReportedItemsApiImpl : ReportedItemsApi {

    private val reportedItems = mutableListOf<ReportedItemDto>().apply {
        repeat(20)
        {
            val request = ReportedItemDto().apply {
                id = it
                name = reportedItemsNames.random()

                postedBy = ContributorDto().apply{
                    username = PostsPlaceholder.organizationName
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }

                itemPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
                description = PostsPlaceholder.description
                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
                locationDescription = "item location"
                lostOrFound = Random.nextBoolean()

            }

            add(request)
        }
    }

    override suspend fun getAllReportedItems(): List<ReportedItemDto> {
        delay(1000)
        return reportedItems
    }

}