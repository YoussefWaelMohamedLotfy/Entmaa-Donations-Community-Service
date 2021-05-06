package com.team.entmaa.data.model.dto.lostandfound

import com.team.entmaa.data.model.dto.tags.TagDto

class ReportedItemDto {
    var id:Int = 0
    var name:String = ""
    var description:String = ""
    var mapsLocation:String = ""
    var createdBy:Int = 0
    var profilePhotoUrl:String = ""
    var resolvedBy:Int = 0
    var lostOrFound:Boolean = true
    var tags:List<TagDto> = listOf()
    var itemPhotosUrls:List<String> = listOf()
}