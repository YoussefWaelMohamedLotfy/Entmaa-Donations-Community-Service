package com.team.entmaa.data.model.dto.auction

import com.team.entmaa.data.model.dto.tags.TagDto
import java.time.ZonedDateTime

class AuctionDto {
    var id:Int = -1
    var title:String = ""
    var description:String = ""
    var startDate:ZonedDateTime = ZonedDateTime.now()
    var endDate:ZonedDateTime = ZonedDateTime.now()
    var startPrice:Int = 0
    var soldPrice:Int = 0
    var madeBy:Int = 0
    var tags:List<TagDto> = listOf()
    var itemPhotosUrls:List<String> = listOf()
}