package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.DonatedItemsApi
import kotlin.random.Random

object DonatedItemsApiImpl : DonatedItemsApi {

//    private val donatedItems = mutableListOf<DonatedItemDto>().apply {
//        repeat(3)
//        {
//            val  donatedItem = DonatedItemDto().apply {
//                id = it
//                itemName = donatedItemNames.random()
//
//                donatedBy = ContributorDto().apply{
//                    username = PostsPlaceholder.organizationName
//                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
//                }
//
//                photoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
//                description = PostsPlaceholder.description
//                tags = mutableListOf<TagDto>().apply {
//                    val random = TagsApiImpl.tags.random()
//                    add(random)
//                }
//
//            }
//
//            add(donatedItem)
//        }
//    }

    val donatedItems = mutableListOf(
        DonatedItemDto().apply {
            itemName = "Winter Clothes"

            donatedBy = ContributorDto().apply{
                username = PostsPlaceholder.contributorNames.random()
                profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
            }

            photoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845372058950041710/wjhat-really-happens-to-our-used-clothing.png"
            description = "Unused winter clothes in new condition"
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }

        },

        DonatedItemDto().apply {
            itemName = "Children toys"

            donatedBy = ContributorDto().apply{
                username = PostsPlaceholder.contributorNames.random()
                profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
            }

            photoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845372032250019890/donate-toys-1604931880.png"
            description = "Toys for children between 3-6 years old"
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }

        }
    )

    override suspend fun addDonatedItem(donatedItemDto: DonatedItemDto, contribId: Int) {

    }

    override suspend fun getAllDonatedItemS(): List<DonatedItemDto> {
        return donatedItems
    }

    override suspend fun getContributorDonatedItems(contribId: Int): List<DonatedItemDto> {
        return donatedItems
    }

    override suspend fun getOrgReceivedDonatedItems(orgId: Int): List<DonatedItemDto> {
        return donatedItems
    }
}