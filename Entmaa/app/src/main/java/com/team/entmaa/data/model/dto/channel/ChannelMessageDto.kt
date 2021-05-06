package com.team.entmaa.data.model.dto.channel

import java.time.ZonedDateTime

class ChannelMessageDto {
    var id:Int = 0
    var channelId:Int = 0
    var userId:Int = 0
    var dateSent:ZonedDateTime = ZonedDateTime.now()
    var message:String = ""
}