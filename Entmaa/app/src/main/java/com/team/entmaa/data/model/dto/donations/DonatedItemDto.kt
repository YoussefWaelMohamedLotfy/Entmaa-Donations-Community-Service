package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto

class DonatedItemDto {
    var id:Int? = null
    var itemName:String? = null
    var description:String? = null
    var isDelivered:Boolean? = null
    var donatedBy:ContributorDto? = null
    var donatedTo:OrganizationDto? = null
    var tags:List<TagDto>? = null
    var photosUrl:String? = null
}