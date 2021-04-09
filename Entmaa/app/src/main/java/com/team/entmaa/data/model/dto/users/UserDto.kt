package com.team.entmaa.data.model.dto.users

import com.team.entmaa.data.model.dto.location.LocationDto
import com.team.entmaa.data.model.dto.tags.TagDto

open class UserDto{
    var id:Int? = null
    var userType:UserTypeDto? = null
    var email:String? = null
    var password:String? = null
    var username:String? = null
    var description:String? = null
    var profilePhotoUrl:String? = null
    var coverPhotoUtl:String? = null
    var firebaseToken:String? = null
    var phoneNumbers:List<String>? = null
    var location: LocationDto? = null
    var tags:List<TagDto>? = null
}
