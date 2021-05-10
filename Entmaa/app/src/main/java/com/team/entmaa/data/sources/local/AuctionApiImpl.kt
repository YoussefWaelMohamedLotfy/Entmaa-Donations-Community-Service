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

    private val auctions = mutableListOf<AuctionDto>().apply {
        repeat(20)
        {
            val request = AuctionDto().apply {
                id = it
                title = auctionTitles.random()
                highestBid = Random.nextInt(100,5000)
                startDate = ZonedDateTime.now().minus(
                    Random.nextLong(63072000),
                    ChronoUnit.SECONDS)
                itemPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
                postedBy = OrganizationDto().apply{
                    username = PostsPlaceholder.organizationName
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }

                description = PostsPlaceholder.description

                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            }

            add(request)
        }
    }


    override suspend fun getAllAuctions(): List<AuctionDto> {
        delay(1000)
        return  auctions
    }

    override suspend fun bidOnAuction(auctionId: Int, bid: BidDto) {
    }
}