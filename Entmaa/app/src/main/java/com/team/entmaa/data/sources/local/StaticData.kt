package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.OrganizationDto


val twoWeeksInSeconds:Long = 1_209_600

//val organizations = listOf(
//    OrganizationDto().apply {
//        username = "Misr El Khair"
//        profilePhotoUrl = "https://s3-eu-west-1.amazonaws.com/wuzzuf/files/company_logo/Misr-El-Kheir-Foundation-Egypt-3428.jpeg"
//    },
//    OrganizationDto().apply {
//        username = "Resala"
//        profilePhotoUrl = "https://img.youm7.com/large/s92009823836.jpg"
//    },
//    OrganizationDto().apply {
//        username = "Children's Cancer Hospital"
//        profilePhotoUrl = "https://www.afnci.org.eg/wp-content/uploads/2019/06/57.jpg"
//    },
//    OrganizationDto().apply {
//        username = "Magdi yacoub foundation"
//        profilePhotoUrl = "https://cdn.shopify.com/s/files/1/2292/2305/files/2018-02-03-magdi-yacoub-foundation-logo-myf-logo_240x240.png?v=1615160245"
//    },
//    OrganizationDto().apply {
//        username = "Al-Orman"
//        profilePhotoUrl = "https://dar-alorman.com/imgs/logos/icon-logo.png"
//    }
//)

val donationRequestsTitles = listOf(
    "Blood donations",
    "Winter clothes",
    "Ramadan donations",
    "Urgent Surgery Needed",
    "Shelter reconstructions"
)

val donationRequests = listOf(
    DonationRequestDto().apply {

    }

)

val contribNames = listOf(
    "Ahmed",
    "Omar",
    "Ali",
    "Beshoy",
    "Amr"
)

val tagNames = setOf(
    "Health",
    "Food",
    "Ramadan",
    "Eid",
    "Blood Donation",
    "House renovations",
    "Orphans",
    "Elderly",
)


val eventsTitles = listOf(
    "Orphan Day",
    "Elderly Day",
    "Winter clothes gathering",
    "Blood Bank",
    "Shelter reconstructions"
)

val reportedItemsNames = listOf(
    "Lost Wallet",
    "Found purse",
    "Phone lost at college",
    "Found a bike at lorem street"
)

val auctionTitles = listOf(
    "Football T-Shirt",
    "lorem item",
    "Mo Salah signed ball",
    "Furniture"
)

val donatedItemNames = listOf(
    "Children Clothes",
    "Toys",
    "Mobile phone",
    "Fan"
)