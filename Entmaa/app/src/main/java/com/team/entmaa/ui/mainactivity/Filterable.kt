package com.team.entmaa.ui.mainactivity

import com.team.entmaa.data.model.dto.tags.TagDto

interface Filterable {

    fun filterByTags(tags: Set<TagDto>)

    fun filterBySearch(searchQuery: String)

}