package com.team.entmaa.ui.mainactivity.reportedItemsfragment

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope

import com.team.entmaa.data.model.dto.lostandfound.ReportedItemDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.sources.remote.ReportedItemsApi
import com.team.entmaa.ui.filters.Filterable
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch


import javax.inject.Inject

@HiltViewModel
class ReportedItemsViewModel @Inject
    constructor(
    private val contributor:ContributorDto,
    private val reportedItemsApi: ReportedItemsApi
)
    : ViewModel() , Filterable {

    private val mReportedItems = MutableLiveData<Result<List<ReportedItemDto>>>()
    val reportedItems : LiveData<Result<List<ReportedItemDto>>> = mReportedItems

    private var activeFilters:Set<TagDto> = setOf()
    private var activeSearch:String = ""

    init {
        refresh()
    }

    override fun filterByTags(tags: Set<TagDto>) {
        activeFilters = tags
        println(activeFilters)
        refresh()
    }

    override fun filterBySearch(searchQuery: String) {
        activeSearch = searchQuery
        refresh()
    }

    fun refresh()
    {
        viewModelScope.launch {
            mReportedItems.value = Result.InProgress

            println("Reuested")
            val response = reportedItemsApi.getAllReportedItems()
            println("Done")
            mReportedItems.value = Result.Success(response
                .filterByTags(activeFilters)
                .filterBySearch(activeSearch))
        }
    }

}


fun Collection<ReportedItemDto>.filterByTags(tags:Collection<TagDto>) : List<ReportedItemDto>
{

    if(tags.isEmpty())
    {
        return this.toList()
    }

    val tagSet = tags.toSet()
    return this.filter {
        it.tags.any { tag ->
            tagSet.contains(tag)
        }
    }
}

fun Collection<ReportedItemDto>.filterBySearch(query:String) : List<ReportedItemDto>
{
    if(query.isEmpty())
    {
        return this.toList()
    }

    return this.filter {
        it.name.contains(query,true) ||
                it.description!!.contains(query,true)
    }
}