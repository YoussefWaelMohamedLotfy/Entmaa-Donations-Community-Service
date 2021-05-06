package com.team.entmaa.data.model.dto.tags

class TagDto {
    var id:Int = 0
    var name:String = ""
    override fun equals(other: Any?): Boolean {
        if (this === other) return true
        if (javaClass != other?.javaClass) return false

        other as TagDto

        if (id != other.id) return false

        return true
    }

    override fun hashCode(): Int {
        return id
    }


}