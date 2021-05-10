package com.team.entmaa.data.model.dto.auction

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import java.time.ZonedDateTime

class AuctionDto {
    var id:Int = -1
    var title:String = ""
    var description:String = ""
    var startDate:ZonedDateTime = ZonedDateTime.now()
    var endDate:ZonedDateTime = ZonedDateTime.now()
    var startPrice:Int = 0
    var soldPrice:Int = 0
    var highestBid:Int = 0
    var postedBy:OrganizationDto = OrganizationDto()
    var tags:List<TagDto> = listOf()
    var itemPhotoUrl:String = ""
}