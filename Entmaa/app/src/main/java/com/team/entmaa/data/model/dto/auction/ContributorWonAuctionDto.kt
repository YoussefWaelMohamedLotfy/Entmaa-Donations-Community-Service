package com.team.entmaa.data.model.dto.auction

import java.time.ZonedDateTime

class ContributorWonAuctionDto {
    var auctionId:Int? = null
    var bidBy:Int? = null
    var price:Int? = null
    var validUntil:ZonedDateTime? = null
    var isPaid:Boolean? = null
    var fawryToken:String? = null
}