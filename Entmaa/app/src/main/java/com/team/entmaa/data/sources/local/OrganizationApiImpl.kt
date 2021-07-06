package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.remote.OrganizationApi
import kotlin.random.Random

object OrganizationApiImpl : OrganizationApi {

    val organizations = listOf(
        OrganizationDto().apply {
            id = 1
            username = "Misr El Khair"
            profilePhotoUrl = "https://s3-eu-west-1.amazonaws.com/wuzzuf/files/company_logo/Misr-El-Kheir-Foundation-Egypt-3428.jpeg"
        },
        OrganizationDto().apply {
            username = "Resala"
            profilePhotoUrl = "https://img.youm7.com/large/s92009823836.jpg"
        },
        OrganizationDto().apply {
            username = "Children's Cancer Hospital"
            profilePhotoUrl = "https://www.afnci.org.eg/wp-content/uploads/2019/06/57.jpg"
        },
        OrganizationDto().apply {
            username = "Magdi yacoub foundation"
            profilePhotoUrl = "https://cdn.shopify.com/s/files/1/2292/2305/files/2018-02-03-magdi-yacoub-foundation-logo-myf-logo_240x240.png?v=1615160245"
        },
        OrganizationDto().apply {
            username = "Al-Orman"
            profilePhotoUrl = "https://dar-alorman.com/imgs/logos/icon-logo.png"
        }
    )

    override fun getAllOrganizations(): List<OrganizationDto> {
        return organizations
    }
}