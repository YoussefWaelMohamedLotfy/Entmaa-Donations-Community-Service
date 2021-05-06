package com.team.entmaa.data.model.dto.users

import java.time.LocalDate

class OrganizationDto : UserDto()
{
    var rating:Int = 0
    var isApproved:Boolean = true
    var dateFounded:LocalDate = LocalDate.now()
    var fawryToken:String = ""
    var followersCount:Int = 0
    var donationRequestsCount:Int = 0
    var eventsCount:Int = 0
    var newsPostsCount:Int = 0
    var albumPhotos:List<String> = listOf()
}
