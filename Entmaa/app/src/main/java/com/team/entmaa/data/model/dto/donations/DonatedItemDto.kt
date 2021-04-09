package com.team.entmaa.data.model.dto.donations

import com.team.entmaa.data.model.dto.tags.TagDto

class DonatedItemDto {
    var id:Int? = null
    var itemName:String? = null
    var description:String? = null
    var isDelivered:Boolean? = null
    var donatedBy:Int? = null
    var donatedTo:Int? = null
    var tags:List<TagDto>? = null
    var itemPhotosUrls:List<String>? = null
}