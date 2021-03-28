package com.team.entmaa.data.repositories

import com.team.entmaa.data.model.domain.DonationRequest
import java.time.ZonedDateTime
import kotlin.random.Random
import kotlin.random.nextInt

object FakeRepository : IRepository {

    override fun getDonationRequests(): List<DonationRequest> {
        val requests = mutableListOf<DonationRequest>()

        repeat(20)
        {
            val randomPhoto = Random.nextInt(1..99)
            val title = "Title ${it + 1}"
            val profilePhotoURL = "https://picsum.photos/200?temp=$randomPhoto"
            val organizationName = "Organization ${it + 1}"
            val timePosted = ZonedDateTime.now()
            val postPhotoURL = "https://picsum.photos/1280/720?temp=$randomPhoto"
            val bodyText = "Body text ${it + 1}"
            val moneyTarget = Random.nextInt(500..9000)
            val moneyCollected = Random.nextInt(1..moneyTarget)
            val currency = "EGP"
            val loveNumber = Random.nextInt(1..99)
            val commentsNumber = Random.nextInt(1..99)


            val post = DonationRequest(title,profilePhotoURL,organizationName,
                    timePosted,postPhotoURL,bodyText,
                    moneyTarget,moneyCollected,currency,loveNumber,commentsNumber
                )

            requests.add(post)
        }

        return requests
    }

}