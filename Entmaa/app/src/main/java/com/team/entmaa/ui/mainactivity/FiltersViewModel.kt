package com.team.entmaa.ui.mainactivity

import androidx.lifecycle.LiveData
import androidx.lifecycle.ViewModel
import com.hadilq.liveevent.LiveEvent
import com.team.entmaa.data.model.dto.tags.TagDto

class FiltersViewModel : ViewModel(), Filterable {

    private val mRefreshState = LiveEvent<Boolean>()
    val refreshState: LiveData<Boolean> = mRefreshState


    private val mAppliedFilters = LiveEvent<List<TagDto>>()
    val appliedFilters: LiveData<List<TagDto>> = mAppliedFilters

    private val mAppliedSearch = LiveEvent<String>()
    val appliedSearch: LiveData<String> = mAppliedSearch

    init {
        mRefreshState.value = false
        mAppliedSearch.value = ""
        mAppliedFilters.value = listOf()
    }

    fun setRefreshing(isRefreshing: Boolean)
    {
        mRefreshState.value = isRefreshing
    }

    override fun filterByTags(tags: List<TagDto>) {
        mAppliedFilters.value = tags
    }

    override fun filterBySearch(searchQuery: String) {
        mAppliedSearch.value = searchQuery
    }


}