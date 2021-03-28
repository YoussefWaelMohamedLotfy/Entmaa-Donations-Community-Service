package com.team.entmaa.data.model.domain

import java.time.ZonedDateTime

data class DonationRequest(
    val title:String,
    val profilePhotoURL:String,
    val organizationName:String,
    val timePosted: ZonedDateTime,
    val postPhotoURL:String,
    val bodyText:String,
    val moneyTarget:Int,
    val moneyCollected:Int,
    val currency:String,
    val loveNumber:Int,
    val commentsNumber:Int
)