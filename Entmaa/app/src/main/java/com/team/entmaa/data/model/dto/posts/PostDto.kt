package com.team.entmaa.data.model.dto.posts

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import java.time.ZonedDateTime

open class PostDto {
    var id:Int = 0
    var title:String = ""
    var timePosted:ZonedDateTime = ZonedDateTime.now()
    var description:String = ""
    var postedBy:OrganizationDto = OrganizationDto()
    var postType:PostTypeDto = PostTypeDto()
    var reactCount:Int = 0
    var isLovedByMe:Boolean = false
    var postPhotoUrl:String = ""
    var comments:List<CommentDto> = listOf()
    var tags:List<TagDto> = listOf()
}