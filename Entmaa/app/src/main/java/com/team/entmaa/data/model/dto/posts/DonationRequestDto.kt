package com.team.entmaa.data.model.dto.posts

class DonationRequestDto : PostDto() {

    var moneyNeededCount:Int = 0
    var moneyReceivedCount:Int = 0

    var itemsAccepted:Boolean = true

    var isFulfilled:Boolean = true

}