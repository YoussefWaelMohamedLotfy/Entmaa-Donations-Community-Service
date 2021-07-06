package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.posts.EventDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.EventsApi
import kotlinx.coroutines.delay
import java.time.LocalDate
import java.time.ZonedDateTime
import java.time.temporal.ChronoUnit
import kotlin.random.Random
import kotlin.random.nextInt

object EventsApiImpl : EventsApi{

//    val feedEvents = mutableListOf<EventDto>().apply {
//        repeat(20)
//        {
//            val request = EventDto().apply {
//                id = it
//                title = eventsTitles.random()
//                timePosted = ZonedDateTime.now().minus(
//                    Random.nextLong(twoWeeksInSeconds),
//                    ChronoUnit.SECONDS)
//                postPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
//                postedBy = OrganizationDto().apply{
//                    username = PostsPlaceholder.organizationName
//                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
//                }
//                description = PostsPlaceholder.description
//                reactCount = Random.nextInt(100..500)
//                comments = List(Random.nextInt(20..200)){ CommentDto() }
//                isLovedByMe = Random.nextBoolean()
//                tags = mutableListOf<TagDto>().apply {
//                    val random = TagsApiImpl.tags.random()
//                    add(random)
//                }
//            }
//
//            add(request)
//        }
//    }


    val feedEvents = mutableListOf(
        EventDto().apply {
                id = 1
                title = "Volunteer to remove illiteracy"
                timePosted = ZonedDateTime.now().minus(
                    Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                postPhotoUrl = "https://www.unv.org/sites/default/files/styles/related_content/public/SouthSudan_Angela1_web.jpg?itok=MMgqsqmt"
                postedBy = OrganizationApiImpl.organizations.random()
                description = "Volunteering can be an incredibly beneficial way for students to utilize their spare time at university"

                startDate = LocalDate.now().plusDays(Random.nextInt(0..5).toLong())
                endDate = startDate.plusDays(Random.nextInt(3..5).toLong())
                reactCount = Random.nextInt(100..500)
                comments = List(Random.nextInt(20..200)){ CommentDto() }
                isLovedByMe = Random.nextBoolean()
                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
        },
        EventDto().apply {
            id = 2
            title = "Volunteer to clean our world"
            timePosted = ZonedDateTime.now().minus(
                Random.nextLong(twoWeeksInSeconds),
                ChronoUnit.SECONDS)

            startDate = LocalDate.now().plusDays(Random.nextInt(0..5).toLong())
            endDate = startDate.plusDays(Random.nextInt(3..5).toLong())
            postPhotoUrl = "https://images.ctfassets.net/81iqaqpfd8fy/6DDS3Y9ViswhYf9FoSIAul/70aa9627efd3c0f5f71251ffb0d41dd4/communityservicemeta.jpg?w=1200&h=1200&fm=jpg&fit=fill"
            postedBy = OrganizationApiImpl.organizations.random()
            description = "Community service is exactly what it sounds like: services" +
                    " that you do to benefit your community. If that sounds a little broad,it’s because it is" +
                    " -- community service can take a lot of different forms since there’s" +
                    " SO much you can do to help folks out in your area"

            reactCount = Random.nextInt(100..500)
            comments = List(Random.nextInt(20..200)){ CommentDto() }
            isLovedByMe = Random.nextBoolean()
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }
        },
        EventDto().apply {
            id = 3
            title = "Orphans Day"
            timePosted = ZonedDateTime.now().minus(
                Random.nextLong(twoWeeksInSeconds),
                ChronoUnit.SECONDS)

            startDate = LocalDate.now().plusDays(Random.nextInt(0..5).toLong())
            endDate = startDate.plusDays(Random.nextInt(3..5).toLong())
            postPhotoUrl = "https://lh3.googleusercontent.com/proxy/KJSKU-D8Cf2o_ZSD0okuB43z9bNhPTJKlo9VyPfDzFy-GeganevMG61US9oaQs5JNJ0LS5Y77vkWS4Fn8UqbFvHK9vF_iZW52cKeOFAXxVyWn0QKA8JWshhR"
            postedBy = OrganizationApiImpl.organizations.random()
            description = "Cheer up orphans, and spend time playing with them"

            reactCount = Random.nextInt(100..500)
            comments = List(Random.nextInt(20..200)){ CommentDto() }
            isLovedByMe = Random.nextBoolean()
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }
        }
    )

    fun getEventById(id:Int) : EventDto
    {
        return feedEvents.find { it.id == id }!!
    }

    override suspend fun getAllEvents(contribId: Int): List<EventDto> {
        delay(1000)
        return feedEvents
    }

    override suspend fun volunteerInEvent(eventId: Int, contribId: Int) {
    }

    override suspend fun getOrgEvents(orgId: Int): List<EventDto> {
        return feedEvents
    }

    override suspend fun createNewEvent(orgId: Int, event: EventDto) {
        feedEvents.add(event)
    }
}