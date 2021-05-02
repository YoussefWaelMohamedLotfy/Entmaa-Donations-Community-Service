package com.team.entmaa.data.sources.moshi

import com.squareup.moshi.FromJson
import com.squareup.moshi.ToJson
import java.time.LocalDate

class LocalDateConverter {

    @ToJson
    fun toJson(input: LocalDate): String {
        return input.toString()
    }

    @FromJson
    fun fromJson(input: String): LocalDate? {
        return LocalDate.now()
    }
}