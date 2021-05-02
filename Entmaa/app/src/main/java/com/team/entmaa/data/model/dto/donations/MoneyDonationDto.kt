package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto

class MoneyDonationDto {
    var id:Int? = null
    var donatedBy:ContributorDto? = null
    var donatedTo:OrganizationDto? = null
    var moneyAmount:Int? = null
    var donationToken:String? = null
}