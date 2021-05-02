package com.team.entmaa.data.sources.moshi

import com.squareup.moshi.FromJson
import com.squareup.moshi.ToJson
import java.time.ZonedDateTime


class ZonedDateTimeConverter {
    @ToJson
    fun toJson(input: ZonedDateTime): String {
        val date: String = input.toLocalDate().toString()
        val time: String = input.toLocalTime().toString()
        val timezone: String = input.getZone().toString()
        return "$date$time$timezone"
    }

    @FromJson
    fun fromJson(input: String): ZonedDateTime? {
        return ZonedDateTime.now()
    }
}