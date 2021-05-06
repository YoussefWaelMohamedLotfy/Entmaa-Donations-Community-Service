package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.ContributorDto

class ItemDonationsOnRequestDto {
    var donatedItem:DonatedItemDto = DonatedItemDto()
    var request:DonationRequestDto = DonationRequestDto()
    var donatedBy:ContributorDto = ContributorDto()
}