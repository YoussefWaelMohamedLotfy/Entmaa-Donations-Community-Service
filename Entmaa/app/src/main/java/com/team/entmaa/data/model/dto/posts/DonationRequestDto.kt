package com.team.entmaa.data.model.dto.posts

class DonationRequestDto : PostDto() {

    var moneyNeededCount:Int? = null
    var moneyReceivedCount:Int? = null

    var itemsNeededCount:Int? = null
    var itemsReceivedCount:Int? = null

    var donationType:DonationTypeDto? = null

    var isFulfilled:Boolean? = null

}