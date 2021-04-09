package com.team.entmaa.data.model.dto.lostandfound

import com.team.entmaa.data.model.dto.tags.TagDto

class ReportedItemDto {
    var id:Int? = null
    var name:String? = null
    var description:String? = null
    var mapsLocation:String? = null
    var createdBy:Int? = null
    var profilePhotoUrl:String? = null
    var resolvedBy:Int? = null
    var lostOrFound:Boolean? = null
    var tags:List<TagDto>? = null
    var itemPhotosUrls:List<String>? = null
}