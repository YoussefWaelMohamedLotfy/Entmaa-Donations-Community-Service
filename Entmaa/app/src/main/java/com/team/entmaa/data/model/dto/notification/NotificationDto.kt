package com.team.entmaa.data.model.dto.notification

class NotificationDto {
    var id:Int = 0
    var deliveredTo:Int = 0
    var isSeen:Boolean = true
    var notificationType:NotificationTypeDto = NotificationTypeDto()
    var triggerId:Int = 0
}