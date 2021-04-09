package com.team.entmaa.data.model.dto.action

import com.team.entmaa.data.model.dto.tags.TagDto
import java.time.ZonedDateTime

class AuctionDto {
    var id:Int? = null
    var title:String? = null
    var description:String? = null
    var startDate:ZonedDateTime? = null
    var endDate:ZonedDateTime? = null
    var startPrice:Int? = null
    var soldPrice:Int? = null
    var madeBy:Int? = null
    var tags:List<TagDto>? = null
    var itemPhotosUrls:List<String>? = null
}