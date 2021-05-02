package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto

class MoneyDonationsOnRequestDto {
    var id:Int? = null
    var donatedBy: ContributorDto? = null
    var donatedTo: OrganizationDto? = null
    var request:DonationRequestDto? = null
    var moneyAmount:Int? = null
    var donationToken:String? = null
}