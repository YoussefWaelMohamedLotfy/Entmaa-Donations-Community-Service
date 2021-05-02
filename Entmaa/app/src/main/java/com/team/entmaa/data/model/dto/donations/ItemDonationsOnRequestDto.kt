package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.ContributorDto

class ItemDonationsOnRequestDto {
    var donatedItem:DonatedItemDto? = null
    var request:DonationRequestDto? = null
    var donatedBy:ContributorDto? = null
}