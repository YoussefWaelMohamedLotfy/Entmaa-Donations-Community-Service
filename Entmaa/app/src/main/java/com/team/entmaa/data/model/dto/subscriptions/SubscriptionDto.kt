package com.team.entmaa.data.model.dto.subscriptions

import java.time.LocalDate

class SubscriptionDto {

    var id:Int? = null
    var subscribedBy:Int? = null
    var subscribedTo:Int? = null
    var IntervalInDays:Int? = null
    var startDate:LocalDate? = null
    var endDate:LocalDate? = null
    var renewalDate:LocalDate? = null
    var moneyAmount:Int? = null
    var isActive:Boolean? = null
}