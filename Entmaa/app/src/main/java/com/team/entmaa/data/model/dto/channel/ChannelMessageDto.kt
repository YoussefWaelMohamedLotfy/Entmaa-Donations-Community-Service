package com.team.entmaa.data.model.dto.channel

import java.time.ZonedDateTime

class ChannelMessageDto {
    var id:Int? = null
    var channelId:Int? = null
    var userId:Int? = null
    var dateSent:ZonedDateTime? = null
    var message:String? = null
}