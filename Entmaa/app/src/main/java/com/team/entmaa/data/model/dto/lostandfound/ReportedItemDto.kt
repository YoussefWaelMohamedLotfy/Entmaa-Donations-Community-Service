package com.team.entmaa.data.model.dto.lostandfound

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import java.time.LocalDate

class ReportedItemDto {
    var id:Int = 0
    var name:String = ""
    var timePosted:LocalDate = LocalDate.now()
    var description:String = ""
    var mapsLocation:String = "geo:30.207276965528077, 31.447550625636186"
    var locationDescription:String = ""
    var postedBy:ContributorDto = ContributorDto()
    var resolvedBy:ContributorDto = ContributorDto()
    var lostOrFound:Boolean = true
    var tags:List<TagDto> = listOf()
    var itemPhotoUrl:String = ""
}