package com.team.entmaa.data.model.dto.users

import com.team.entmaa.data.model.dto.location.LocationDto
import com.team.entmaa.data.model.dto.tags.TagDto

open class UserDto{
    var id:Int = 0
    var userType:UserTypeDto = UserTypeDto()
    var email:String = ""
    var password:String = ""
    var username:String = ""
    var description:String = ""
    var profilePhotoUrl:String = ""
    var coverPhotoUrl:String = ""
    var firebaseToken:String = ""
    var phoneNumber:String = "01027493077"
    var location: LocationDto = LocationDto()
    var tags:List<TagDto> = listOf()
}

fun test()
{
    UserDto().apply {
        description = "New description"
    }
}
