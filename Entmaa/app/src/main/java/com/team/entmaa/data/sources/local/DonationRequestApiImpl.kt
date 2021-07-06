package com.team.entmaa.data.sources.local

import com.skydoves.sandwich.ApiResponse
import com.team.entmaa.data.model.dto.ApiResponseMessage
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import kotlinx.coroutines.delay
import retrofit2.Response
import java.time.ZonedDateTime
import java.time.temporal.ChronoUnit
import kotlin.random.Random
import kotlin.random.nextInt

object DonationRequestApiImpl : DonationRequestsApi {

//    val donationRequests = mutableListOf<DonationRequestDto>().apply {
//        repeat(20)
//        {
//            val request = DonationRequestDto().apply {
//                id = it
//                title = donationRequestsTitles.random()
//                timePosted = ZonedDateTime.now().minus(Random.nextLong(twoWeeksInSeconds),
//                    ChronoUnit.SECONDS)
//                postPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
//                postedBy = OrganizationApiImpl.organizations.random()
//                description = PostsPlaceholder.description
//                moneyNeededCount = Random.nextInt(1000..9000)
//                val needed:Int = moneyNeededCount!!
//                moneyReceivedCount = Random.nextInt(200..needed)
//                reactCount = Random.nextInt(100..500)
//                comments = List(Random.nextInt(20..200)){ CommentDto()}
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

    val donationRequests = mutableListOf(
        DonationRequestDto()
        .apply {
            title = "Donate to Children in Africa"
            timePosted = ZonedDateTime.now().minus(Random.nextLong(twoWeeksInSeconds),
                ChronoUnit.SECONDS)
            postPhotoUrl = "https://www.volunteerforever.com/wp-content/uploads/2019/08/nairobi-kenya-min.jpg"
            postedBy = OrganizationApiImpl.organizations.random()
            description = "Being from a vast, varied, and majestic continent," +
                    " the children of Africa live in a diverse range of places," +
                    " from cosmopolitan cities to small villages. As economies in" +
                    " the region continue to push ahead and create better standards" +
                    " of living for the people, it’s up to tomorrow’s leaders to secure" +
                    " a prosperous, peaceful future"
            moneyNeededCount = Random.nextInt(1000..9000)
            val needed:Int = moneyNeededCount!!
            moneyReceivedCount = Random.nextInt(200..needed)
            reactCount = Random.nextInt(100..500)
            comments = List(Random.nextInt(20..200)){ CommentDto()}
            isLovedByMe = Random.nextBoolean()
            tags = mutableListOf<TagDto>().apply {
                val random = TagsApiImpl.tags.random()
                add(random)
            }
        },
        DonationRequestDto()
            .apply {
                title = "Support Volunteer tourism"
                timePosted = ZonedDateTime.now().minus(Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                postPhotoUrl = "https://cms.qz.com/wp-content/uploads/2017/11/rtx1ezzy-e1510249290802.jpg?quality=75&strip=all&w=410&h=231"
                postedBy = OrganizationApiImpl.organizations.random()
                description = "Volunteer tourism, or voluntourism, is" +
                        " an emerging trend of travel linked to “doing good”." +
                        " Yet these efforts to help people and the environment" +
                        " have come under heavy criticism – I believe for good reason."
                moneyNeededCount = Random.nextInt(1000..9000)
                val needed:Int = moneyNeededCount!!
                moneyReceivedCount = Random.nextInt(200..needed)
                reactCount = Random.nextInt(100..500)
                comments = List(Random.nextInt(20..200)){ CommentDto()}
                isLovedByMe = Random.nextBoolean()
                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            },
        DonationRequestDto()
            .apply {
                title = "Donations needed in kenya"
                timePosted = ZonedDateTime.now().minus(Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                postPhotoUrl = "https://cdn.locomotive.works/sites/5ab130be74c4833febe6b45a/content_entry5aba37ba74c4837dc15d1b7f/5aba38c974c4837dc15d1cb1/files/hiv-prevention-work-in-kenya-min.jpg?1584092744"
                postedBy = OrganizationApiImpl.organizations.random()
                description = "Help put a smile on their faces"
                moneyNeededCount = Random.nextInt(1000..9000)
                val needed:Int = moneyNeededCount!!
                moneyReceivedCount = Random.nextInt(200..needed)
                reactCount = Random.nextInt(100..500)
                comments = List(Random.nextInt(20..200)){ CommentDto()}
                isLovedByMe = Random.nextBoolean()
                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            },
        DonationRequestDto()
            .apply {
                title = "Yemen needs your support"
                timePosted = ZonedDateTime.now().minus(Random.nextLong(twoWeeksInSeconds),
                    ChronoUnit.SECONDS)
                postPhotoUrl = "https://backtojerusalem.com/wp-content/uploads/2021/03/yemen.jpg"
                postedBy = OrganizationApiImpl.organizations.random()
                description = "A humanitarian crisis is ravaging Yemen, leaving tens of thousands dead in its wake and very little is being reported about it"
                moneyNeededCount = Random.nextInt(1000..9000)
                val needed:Int = moneyNeededCount!!
                moneyReceivedCount = Random.nextInt(200..needed)
                reactCount = Random.nextInt(100..500)
                comments = List(Random.nextInt(20..200)){ CommentDto()}
                isLovedByMe = Random.nextBoolean()
                tags = mutableListOf<TagDto>().apply {
                    val random = TagsApiImpl.tags.random()
                    add(random)
                }
            },

    )

    override suspend fun getDonationRequestsFeed(contributorId: Int): ApiResponse<List<DonationRequestDto>> {

        delay(1000)

        return ApiResponse.Success(Response.success(donationRequests))
    }

    override suspend fun getDonationRequestsPostedByOrg(orgId: Int): ApiResponse<List<DonationRequestDto>> {
        return ApiResponse.of { Response.success(donationRequests) }
    }

    override suspend fun getMoneyDonationsOnRequest(requestId: Int): ApiResponse<List<MoneyDonationsOnRequestDto>> {
        TODO("Not yet implemented")
    }

    override suspend fun getItemDonationsOnRequest(requestId: Int): ApiResponse<List<ItemDonationsOnRequestDto>> {
        TODO("Not yet implemented")
    }

    override suspend fun donateMoneyToRequest(
        requestId: Int,
        moneyDonation: MoneyDonationsOnRequestDto
    ) : ApiResponse<ApiResponseMessage>{
        delay(2000)
        return ApiResponse.of { Response.success(ApiResponseMessage("")) }
    }

    override suspend fun createNewDonationRequest(orgId: Int, request: DonationRequestDto) {
        donationRequests.add(request)
    }

}