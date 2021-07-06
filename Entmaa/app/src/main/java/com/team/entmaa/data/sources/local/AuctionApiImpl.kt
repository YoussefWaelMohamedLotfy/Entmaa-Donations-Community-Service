package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.auction.AuctionDto
import com.team.entmaa.data.model.dto.auction.BidDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.AuctionApi
import kotlinx.coroutines.delay
import java.time.ZonedDateTime
import java.time.temporal.ChronoUnit
import kotlin.random.Random

object AuctionApiImpl : AuctionApi{

//    private val auctions = mutableListOf<AuctionDto>().apply {
//        repeat(20)
//        {
//            val request = AuctionDto().apply {
//                id = it
//                title = auctionTitles.random()
//                highestBid = Random.nextInt(100,5000)
//                startDate = ZonedDateTime.now().minus(
//                    Random.nextLong(63072000),
//                    ChronoUnit.SECONDS)
//                itemPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
//                postedBy = OrganizationDto().apply{
//                    username = PostsPlaceholder.organizationName
//                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
//                }
//
//                description = PostsPlaceholder.description
//
//                tags = mutableListOf<TagDto>().apply {
//                    val random = TagsApiImpl.tags.random()
//                    add(random)
//                }
//            }
//
//            add(request)
//        }
//    }

    val auctions = mutableListOf(
        AuctionDto()
            .apply {
                title = "Mo Salah signed ball"
                highestBid = Random.nextInt(100,5000)
                startDate = ZonedDateTime.now().minus(
                    Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                itemPhotoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845300265162375198/9k.png"
                postedBy = OrganizationApiImpl.organizations.random()

                description = "A ball hand signed by Mohamad Salah "

                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            },
        AuctionDto()
            .apply {
                title = "Photo by the artist Ahmed Safwat"
                highestBid = Random.nextInt(100,5000)
                startDate = ZonedDateTime.now().minus(
                    Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                itemPhotoUrl = "https://media.discordapp.net/attachments/834772735447662623/845300906135912498/AP_19025488463362-640x400.png"
                postedBy = OrganizationApiImpl.organizations.random()

                description = "Exclusive photo hand signed by the one and only Ahmed Safwat"

                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            },
        AuctionDto()
            .apply {
                title = "A memorable shakespeare poem book"
                highestBid = Random.nextInt(100,5000)
                startDate = ZonedDateTime.now().minus(
                    Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                itemPhotoUrl = "https://cdn.discordapp.com/attachments/834772735447662623/845299712257032233/images.png"
                postedBy = OrganizationApiImpl.organizations.random()

                description = "A book containing hundreds of historic poems written by william shakespeare"

                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            }
    )


    override suspend fun getAllAuctions(): List<AuctionDto> {
        delay(1000)
        return  auctions
    }

    override suspend fun bidOnAuction(auctionId: Int, bid: BidDto) {
    }

    override suspend fun getOrgAuctions(orgId: Int): List<AuctionDto> {
        return auctions
    }

    override suspend fun createNewAuction(orgId: Int, auction: AuctionDto) {
        auctions.add(auction)
    }
}