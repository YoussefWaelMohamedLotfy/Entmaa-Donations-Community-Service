package com.team.entmaa.data.model.dto.posts

import com.team.entmaa.data.model.dto.tags.TagDto
import java.time.ZonedDateTime

open class PostDto {
    var id:Int? = null
    var title:String? = null
    var timePosted:ZonedDateTime? = null
    var description:String? = null
    var postedBy:Int? = null
    var postType:PostTypeDto? = null
    var reactCount:Int? = null
    var profilePhotoUrl:String? = null
    var postPhotoUrl:String? = null
    var commentsList:List<CommentDto>? = null
    var tags:List<TagDto>? = null
}