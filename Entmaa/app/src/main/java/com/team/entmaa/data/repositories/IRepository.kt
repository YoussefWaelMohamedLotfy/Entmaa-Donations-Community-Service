package com.team.entmaa.data.repositories

import com.team.entmaa.data.model.domain.DonationRequest

interface IRepository {

    fun getDonationRequests() : List<DonationRequest>

}