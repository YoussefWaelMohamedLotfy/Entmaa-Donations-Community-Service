package com.team.entmaa.data.model.dto.posts

import java.time.ZonedDateTime

class CommentDto {
    var id:Int? = null
    var postId:Int? = null
    var userId:Int? = null
    var userName:String? = null
    var userPhotoUrl:String? = null
    var commentText:String? = null
    var timePosted:ZonedDateTime? = null
}