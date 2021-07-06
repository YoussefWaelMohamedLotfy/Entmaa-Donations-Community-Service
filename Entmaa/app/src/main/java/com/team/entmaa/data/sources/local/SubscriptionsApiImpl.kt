package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.data.model.dto.subscriptions.SubscriptionDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.SubscriptionsApi
import java.time.LocalDate
import kotlin.random.Random

object SubscriptionsApiImpl : SubscriptionsApi{

    val subscriptions = mutableListOf<SubscriptionDto>().apply {
        repeat(3)
        {
            val subscription = SubscriptionDto().apply {
                name = "Monthly donation reminder to " + OrganizationApiImpl.organizations.random().username
                intervalInDays = 30
                startDate = LocalDate.now()
                moneyAmount = 500
            }

            add(subscription)
        }
    }

    override suspend fun addNewSubscription(contribId: Int, subscription: SubscriptionDto) {

    }

    override suspend fun getContributorSubscriptions(contribId: Int): List<SubscriptionDto> {
        return subscriptions
    }
}