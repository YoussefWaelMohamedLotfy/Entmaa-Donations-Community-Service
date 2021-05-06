package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto

class MoneyDonationsOnRequestDto {
    var id:Int = 0
    var donatedBy: ContributorDto = ContributorDto()
    var donatedTo: OrganizationDto = OrganizationDto()
    var request:DonationRequestDto = DonationRequestDto()
    var moneyAmount:Int = 0
    var donationToken:String = ""
}