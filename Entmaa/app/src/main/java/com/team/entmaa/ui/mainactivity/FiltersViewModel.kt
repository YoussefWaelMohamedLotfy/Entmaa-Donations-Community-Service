package com.team.entmaa.ui.mainactivity

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.hadilq.liveevent.LiveEvent
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.sources.remote.TagsApi
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject


@HiltViewModel
class FiltersViewModel @Inject constructor(
    private val tagsApi: TagsApi
) : ViewModel(), Filterable {

    private val mUserTriggeredRefresh = LiveEvent<Boolean>()
    val userTriggeredRefresh:LiveData<Boolean> = mUserTriggeredRefresh

    private val mRequestTriggeredRefresh = LiveEvent<Boolean>()
    val requestTriggeredRefresh:LiveData<Boolean> = mRequestTriggeredRefresh

    private val mAppliedFilters = LiveEvent<Set<TagDto>>()
    val appliedFilters: LiveData<Set<TagDto>> = mAppliedFilters

    private val mAppliedSearch = LiveEvent<String>()
    val appliedSearch: LiveData<String> = mAppliedSearch


    private val mFilters = MutableLiveData<Set<TagDto>>()
    val filters:LiveData<Set<TagDto>> = mFilters

    init {
        mAppliedSearch.value = ""
        mAppliedFilters.value = setOf()

        viewModelScope.launch {
            mFilters.value = tagsApi.getAllTags()
        }
    }

    fun userRequestedRefresh()
    {
        mUserTriggeredRefresh.value = true
    }

    fun setRefreshing(isRefreshing: Boolean)
    {
        mRequestTriggeredRefresh.value = isRefreshing
    }

    override fun filterByTags(tags: Set<TagDto>) {
        mAppliedFilters.value = tags
    }

    override fun filterBySearch(searchQuery: String) {
        mAppliedSearch.value = searchQuery
    }


}