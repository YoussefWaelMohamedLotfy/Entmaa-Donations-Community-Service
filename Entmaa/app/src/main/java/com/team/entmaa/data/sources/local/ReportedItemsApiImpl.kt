package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.ReportedItemsApi
import kotlinx.coroutines.delay
import kotlin.random.Random

object ReportedItemsApiImpl : ReportedItemsApi {

//    private val reportedItems = mutableListOf<ReportedItemDto>().apply {
//        repeat(20)
//        {
//            val request = ReportedItemDto().apply {
//                id = it
//                name = reportedItemsNames.random()
//
//                postedBy = ContributorDto().apply{
//                    username = PostsPlaceholder.organizationName
//                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
//                }
//
//                itemPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
//                description = PostsPlaceholder.description
//                tags = mutableListOf<TagDto>().apply {
//                    val random = TagsApiImpl.tags.random()
//                    add(random)
//                }
//                locationDescription = "Ain shams university"
//                lostOrFound = Random.nextBoolean()
//
//            }
//
//            add(request)
//        }
//    }

    val reportedItems = mutableListOf(
        ReportedItemDto().apply {
            name = "A found Wallet"

            postedBy = ContributorDto().apply{
                username = contribNames.random()
                profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
            }

            itemPhotoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845365453215236126/Wallet-lost-53-years-ago-in-Antarctica-returned-to-owner.png"
            description = "I found a wallet containing 1300 EGP please contact me if it is yours"
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }
            locationDescription = "Ain shams university"
            lostOrFound = false

        },

        ReportedItemDto().apply {
            name = "Lost watch at ain shams"

            postedBy = ContributorDto().apply{
                username = contribNames.random()
                profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
            }

            itemPhotoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845365834503422043/main-qimg-b7419b8c0d0475716548a321500d87ff.png"
            description = "I found a wallet containing 1300 EGP please contact me if it is yours"
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }
            locationDescription = "Ain shams university"
            lostOrFound = true

        },

        ReportedItemDto().apply {
            name = "A lost child"

            postedBy = ContributorDto().apply{
                username = contribNames.random()
                profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
            }

            itemPhotoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845366934958768138/crying-child-lost-5790ff895f9b58cdf3c43860.png"
            description = "A 6 year old was lost at xyz park please help"
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }
            locationDescription = "Ain shams university"
            lostOrFound = true

        }
    )

    override suspend fun getAllReportedItems(): List<ReportedItemDto> {
        delay(1000)
        return reportedItems
    }

}