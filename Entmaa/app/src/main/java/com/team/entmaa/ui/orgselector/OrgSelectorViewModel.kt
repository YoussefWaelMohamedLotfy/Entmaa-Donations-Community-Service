package com.team.entmaa.ui.orgselector

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.OrganizationApi
import dagger.hilt.android.lifecycle.HiltViewModel
import kotlinx.coroutines.launch
import javax.inject.Inject

@HiltViewModel
class OrgSelectorViewModel @Inject constructor(
    private val orgApi:OrganizationApi
) : ViewModel() {

    private lateinit var allOrganization:List<OrganizationDto>

    private val mOrganizations = MutableLiveData<List<OrganizationDto>>()
    val organization:LiveData<List<OrganizationDto>> = mOrganizations

    private val mSelectedOrganization = MutableLiveData<OrganizationDto>()
    val selectedOrganization:LiveData<OrganizationDto> = mSelectedOrganization

    init {
        viewModelScope.launch {
            allOrganization = orgApi.getAllOrganizations()
            mOrganizations.value = allOrganization
        }
    }

    fun setSelectedOrg(org:OrganizationDto)
    {
        mSelectedOrganization.value = org
    }

    fun searchOrgs(orgName:String)
    {
        mOrganizations.value = allOrganization.filterByName(orgName)
    }

}

fun List<OrganizationDto>.filterByName(orgName:String) : List<OrganizationDto>
{
    if(orgName.isEmpty())
    {
        return this
    }

    return this.filter { it.username.contains(orgName) }
}