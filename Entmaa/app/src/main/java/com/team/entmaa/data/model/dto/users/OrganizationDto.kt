package com.team.entmaa.data.model.dto.users

import java.time.LocalDate

class OrganizationDto : UserDto()
{
    var rating:Int? = null
    var isApproved:Boolean? = null
    var dateFounded:LocalDate? = null
    var fawryToken:String? = null
    var followersCount:Int? = null
    var donationRequestsCount:Int? = null
    var eventsCount:Int? = null
    var newsPostsCount:Int? = null
    var albumPhotos:List<String>? = null
}
