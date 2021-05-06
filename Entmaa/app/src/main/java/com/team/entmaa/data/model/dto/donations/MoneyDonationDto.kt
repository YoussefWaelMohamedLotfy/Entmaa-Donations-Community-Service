package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto

class MoneyDonationDto {
    var id:Int = 0
    var donatedBy:ContributorDto = ContributorDto()
    var donatedTo:OrganizationDto = OrganizationDto()
    var moneyAmount:Int = 0
    var donationToken:String = ""
}