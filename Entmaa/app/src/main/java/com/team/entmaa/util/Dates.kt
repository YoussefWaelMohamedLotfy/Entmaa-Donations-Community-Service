package com.team.entmaa.util

import java.time.*
import java.time.temporal.Temporal


fun LocalDate.durationFrom(dateTime: LocalDate) : String
{

    val duration = Duration.between(this,dateTime)

    val period = Period.between(this,dateTime)

    /*val seconds = period
    val days = period.days
    val month = period.months

    if(days < 32)
    {
        return "$daysNumber days"
    }*/
    

    return  "months"
}
