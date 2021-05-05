package com.team.entmaa.util

import java.time.*
import java.time.temporal.ChronoUnit
import kotlin.math.abs


fun LocalDateTime.durationFrom(from: LocalDateTime) : String
{

    val seconds: Long = abs(ChronoUnit.SECONDS.between(this, from))
    val minutes:Int = seconds.toInt() / 60
    val hours = minutes / 60
    val days = hours / 24
    val weeks = days / 7
    val months = weeks / 4
    val years = months / 12

    val durations = listOf(
        years to "years",
        months to "months",
        weeks to "weeks",
        days to "days",
        hours to "hours",
        minutes to "minutes",
        seconds to "seconds"
    )

    return durations.first { it.first != 0 }
        .let {
            var unit = it.second
            if(it.first == 1)
            {
                unit = unit.dropLast(1)
            }
            "${it.first} $unit"
        }
}
