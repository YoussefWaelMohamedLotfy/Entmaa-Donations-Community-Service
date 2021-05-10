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

    val donationRequests = mutableListOf<DonationRequestDto>().apply {
        repeat(20)
        {
            val request = DonationRequestDto().apply {
                id = it
                title = donationRequestsTitles.random()
                timePosted = ZonedDateTime.now().minus(Random.nextLong(63072000),
                    ChronoUnit.SECONDS)
                postPhotoUrl = PostsPlaceholder.postPhotoUrl + Random.nextInt()
                postedBy = OrganizationDto().apply{
                    username = PostsPlaceholder.organizationName
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }
                description = PostsPlaceholder.description
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
            }

            add(request)
        }
    }

    override suspend fun getDonationRequestsFeed(contributorId: Int): ApiResponse<List<DonationRequestDto>> {

        delay(1000)

        return ApiResponse.Success(Response.success(donationRequests))
    }

    override suspend fun getDonationRequestsPostedByOrg(orgId: Int): ApiResponse<List<DonationRequestDto>> {
        TODO("Not yet implemented")
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
}