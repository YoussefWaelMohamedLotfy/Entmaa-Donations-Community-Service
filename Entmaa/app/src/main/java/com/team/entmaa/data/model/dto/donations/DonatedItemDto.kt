package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto

class DonatedItemDto {
    var id:Int = 0
    var itemName:String = ""
    var description:String = ""
    var isDelivered:Boolean = true
    var donatedBy:ContributorDto = ContributorDto()
    var donatedTo:OrganizationDto = OrganizationDto()
    var tags:List<TagDto> = listOf()
    var photosUrl:String = ""
}