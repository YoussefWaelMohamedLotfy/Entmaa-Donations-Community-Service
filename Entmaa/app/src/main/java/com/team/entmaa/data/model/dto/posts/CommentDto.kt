package com.team.entmaa.data.model.dto.posts

import com.team.entmaa.data.model.dto.users.UserDto
import java.time.ZonedDateTime

class CommentDto {
    var id:Int? = null
    var commentedBy:UserDto? = null
    var commentText:String? = null
    var timePosted:ZonedDateTime? = null
}