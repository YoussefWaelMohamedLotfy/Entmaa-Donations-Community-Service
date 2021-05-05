package com.team.entmaa.ui.mainactivity

import com.team.entmaa.data.model.dto.tags.TagDto

interface Filterable {

    fun filterByTags(tags: List<TagDto>)

    fun filterBySearch(searchQuery: String)

}