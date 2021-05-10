package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.sources.remote.TagsApi

object TagsApiImpl : TagsApi{

    val tags =  mutableSetOf<TagDto>().apply {
        repeat(20){

            val tag = TagDto().apply {
                id = it
                name = "Tag ${it + 1}"
            }

            add(tag)
        }
    }



    override suspend fun getAllTags(): Set<TagDto> {
        return tags
    }
}