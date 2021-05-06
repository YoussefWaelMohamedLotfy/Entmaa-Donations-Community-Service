package com.team.entmaa.data.model.dto.auction

import java.time.ZonedDateTime

class ContributorWonAuctionDto {
    var auctionId:Int = 0
    var bidBy:Int = 0
    var price:Int = 0
    var validUntil:ZonedDateTime = ZonedDateTime.now()
    var isPaid:Boolean = true
    var fawryToken:String = ""
}