package com.team.entmaa.util

import com.team.entmaa.data.model.dto.posts.PostDto
import com.team.entmaa.data.model.dto.tags.TagDto

fun <T : PostDto> Collection<T>.filterByTags(tags:Collection<TagDto>) : List<T>
{

    if(tags.isEmpty())
    {
        return this.toList()
    }

    val tagSet = tags.toSet()
    return this.filter {
        it.tags!!.any { tag ->
            tagSet.contains(tag)
        }
    }
}

fun <T : PostDto>Collection<T>.filterBySearch(query:String) : List<T>
{
    if(query.isEmpty())
    {
        return this.toList()
    }

    return this.filter {
        it.title!!.contains(query,true) ||
        it.description!!.contains(query,true)
    }
}