package com.team.entmaa.data.model.dto.posts

class DonationRequestDto : PostDto() {

    var moneyNeededCount:Int? = null
    var moneyReceivedCount:Int? = null

    var itemsAccepted:Boolean? = null

    var isFulfilled:Boolean? = null

}