package com.team.entmaa.data.sources.local

import com.skydoves.sandwich.ApiResponse
import com.team.entmaa.data.model.dto.donations.ItemDonationsOnRequestDto
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.DonatonRequestsApi
import com.team.entmaa.util.FakePosts
import kotlinx.coroutines.delay
import kotlinx.coroutines.runBlocking
import retrofit2.Response
import java.time.ZonedDateTime
import java.time.temporal.ChronoUnit
import kotlin.random.Random
import kotlin.random.nextInt

object FakeDonationRequestApi : DonatonRequestsApi {
    override suspend fun getDonationRequestsFeed(contributorId: Int): ApiResponse<List<DonationRequestDto>> {

        delay(3000)

        val result = mutableListOf<DonationRequestDto>().apply {
            repeat(20)
            {
                val request = DonationRequestDto().apply {
                    id = it
                    title = FakePosts.title
                    timePosted = ZonedDateTime.now().minus(Random.nextLong(63072000),
                        ChronoUnit.SECONDS)
                    postPhotoUrl = FakePosts.postPhotoUrl + Random.nextInt()
                    postedBy = OrganizationDto().apply{
                        username = FakePosts.organizationName
                        profilePhotoUrl = FakePosts.profilePhotoUrl + Random.nextInt()
                    }
                    description = FakePosts.description
                    moneyNeededCount = Random.nextInt(1000..9000)
                    val needed:Int = moneyNeededCount!!
                    moneyReceivedCount = Random.nextInt(200..needed)
                    reactCount = Random.nextInt(100..500)
                    comments = List(Random.nextInt(20..200)){ CommentDto()}
                }

                add(request)
            }
        }

        return ApiResponse.Success(Response.success(result))
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
}