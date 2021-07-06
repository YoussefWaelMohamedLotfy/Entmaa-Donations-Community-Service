package com.team.entmaa.ui.mainactivity.auctionfragment

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.team.entmaa.data.model.dto.auction.AuctionDto
import com.team.entmaa.data.model.dto.auction.BidDto
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.repositories.Result
import com.team.entmaa.data.sources.remote.AuctionApi
import com.team.entmaa.ui.filters.Filterable
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch


import javax.inject.Inject

@HiltViewModel
class AuctionViewModel @Inject
    constructor(
    private val contributor:ContributorDto,
    private val auctionApi: AuctionApi
)
    : ViewModel() , Filterable {

    private val mAuctions = MutableLiveData<Result<List<AuctionDto>>>()
    val auctions : LiveData<Result<List<AuctionDto>>> = mAuctions

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
            mAuctions.value = Result.InProgress
            val response = auctionApi.getAllAuctions()

                mAuctions.value = Result.Success(response
                .filterByTags(activeFilters)
                .filterBySearch(activeSearch))
        }
    }

    fun bidOnAuction(bidDto: BidDto)
    {
        viewModelScope.launch {
            auctionApi.bidOnAuction(bidDto.auctionId,bidDto)
        }
    }


}


fun Collection<AuctionDto>.filterByTags(tags:Collection<TagDto>) : List<AuctionDto>
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

fun Collection<AuctionDto>.filterBySearch(query:String) : List<AuctionDto>
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