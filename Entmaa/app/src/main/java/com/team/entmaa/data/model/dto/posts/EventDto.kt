package com.team.entmaa.data.model.dto.posts

import com.team.entmaa.data.model.dto.location.LocationDto
import java.time.LocalDate

class EventDto : PostDto() {
    var startDate:LocalDate? = null
    var endDate:LocalDate? = null
    var location: LocationDto? = null
    var interestedNumber:Int? = null
    var neededNumber:Int? = null
    var acceptedNumber:Int? = null
}