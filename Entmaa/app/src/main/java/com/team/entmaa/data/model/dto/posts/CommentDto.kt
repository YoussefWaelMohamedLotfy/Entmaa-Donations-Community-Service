package com.team.entmaa.data.model.dto.posts

import com.team.entmaa.data.model.dto.users.UserDto
import java.time.ZonedDateTime

class CommentDto {
    var id:Int = 0
    var commentedBy:UserDto = UserDto()
    var commentText:String = ""
    var timePosted:ZonedDateTime = ZonedDateTime.now()
}