package com.team.entmaa.data.model.dto.subscriptions

import java.time.LocalDate

class SubscriptionDto {

    var id:Int = 0
    var subscribedBy:Int = 0
    var subscribedTo:Int = 0
    var IntervalInDays:Int = 0
    var startDate:LocalDate = LocalDate.now()
    var endDate:LocalDate = LocalDate.now()
    var renewalDate:LocalDate = LocalDate.now()
    var moneyAmount:Int = 0
    var isActive:Boolean = true
}