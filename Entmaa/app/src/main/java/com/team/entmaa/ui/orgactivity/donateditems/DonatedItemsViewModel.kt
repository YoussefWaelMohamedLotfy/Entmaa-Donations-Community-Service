package com.team.entmaa.ui.orgactivity.donateditems

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.team.entmaa.data.model.dto.donations.DonatedItemDto

import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.sources.remote.DonatedItemsApi
import com.team.entmaa.ui.filters.Filterable
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch


import javax.inject.Inject

@HiltViewModel
class DonatedItemsViewModel @Inject
    constructor(
    private val donatedItemsApi: DonatedItemsApi
)
    : ViewModel() , Filterable {

    private val mDonatedItems = MutableLiveData<Result<List<DonatedItemDto>>>()
    val donatedItems : LiveData<Result<List<DonatedItemDto>>> = mDonatedItems

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
            mDonatedItems.value = Result.InProgress

            println("Reuested")
            val response = donatedItemsApi.getAllDonatedItemS()
            println("Done")
            mDonatedItems.value = Result.Success(response
                .filterByTags(activeFilters)
                .filterBySearch(activeSearch))
        }
    }

}


fun Collection<DonatedItemDto>.filterByTags(tags:Collection<TagDto>) : List<DonatedItemDto>
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

fun Collection<DonatedItemDto>.filterBySearch(query:String) : List<DonatedItemDto>
{
    if(query.isEmpty())
    {
        return this.toList()
    }

    return this.filter {
        it.itemName.contains(query,true) ||
                it.description!!.contains(query,true)
    }
}