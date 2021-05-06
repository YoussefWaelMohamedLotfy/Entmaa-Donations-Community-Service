package com.team.entmaa.data.model.dto.posts

import com.team.entmaa.data.model.dto.location.LocationDto
import java.time.LocalDate

class EventDto : PostDto() {
    var startDate:LocalDate = LocalDate.now()
    var endDate:LocalDate = LocalDate.now()
    var location: LocationDto = LocationDto()
    var interestedNumber:Int = 0
    var neededNumber:Int = 0
    var acceptedNumber:Int = 0
}