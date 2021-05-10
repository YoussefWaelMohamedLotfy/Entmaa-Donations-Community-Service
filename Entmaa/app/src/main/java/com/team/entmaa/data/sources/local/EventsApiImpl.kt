package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.posts.EventDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.EventsApi
import kotlinx.coroutines.delay
import java.time.ZonedDateTime
import java.time.temporal.ChronoUnit
import kotlin.random.Random
import kotlin.random.nextInt

object EventsApiImpl : EventsApi{

    val events = mutableListOf<EventDto>().apply {
        repeat(20)
        {
            val request = EventDto().apply {
                id = it
                title = eventsTitles.random()
                timePosted = ZonedDateTime.now().minus(
                    Random.nextLong(63072000),
                    ChronoUnit.SECONDS)
                postPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
                postedBy = OrganizationDto().apply{
                    username = PostsPlaceholder.organizationName
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }
                description = PostsPlaceholder.description
                reactCount = Random.nextInt(100..500)
                comments = List(Random.nextInt(20..200)){ CommentDto() }
                isLovedByMe = Random.nextBoolean()
                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            }

            add(request)
        }
    }


    override suspend fun getAllEvents(contribId: Int): List<EventDto> {
        delay(1000)
        return events
    }

    override suspend fun volunteerInEvent(eventId: Int, contribId: Int) {
    }
}