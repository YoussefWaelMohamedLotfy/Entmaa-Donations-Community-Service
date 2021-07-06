package com.team.entmaa.di

import android.content.Context
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.model.dto.users.OrganizationDto
import com.team.entmaa.data.sources.local.PostsPlaceholder
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.qualifiers.ApplicationContext
import dagger.hilt.components.SingletonComponent
import kotlin.random.Random


@Module
@InstallIn(SingletonComponent::class)
object SharedPreferencesModule {

    @Provides
    fun provideContribId(@ApplicationContext context: Context) : ContributorDto
    {
        val fileName = context.getString(R.string.GlobalSharedPreferences)
        val key = context.getString(R.string.Key_LoggedInContribId)
        val contribId =  context.getSharedPreferences(fileName,Context.MODE_PRIVATE)
            .getInt(key,-1)

        return ContributorDto().apply {
            id = contribId
            username = "Ahmed"
            profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
        }
    }

    @Provides
    fun provideOrgId(@ApplicationContext context: Context) : OrganizationDto
    {
        val fileName = context.getString(R.string.GlobalSharedPreferences)
        val key = context.getString(R.string.Key_LoggedInOrgId)
        val orgId =  context.getSharedPreferences(fileName,Context.MODE_PRIVATE)
            .getInt(key,-1)

        return OrganizationDto().apply {
            id = 1
            username = "Misr El Khair"
            profilePhotoUrl = "https://s3-eu-west-1.amazonaws.com/wuzzuf/files/company_logo/Misr-El-Kheir-Foundation-Egypt-3428.jpeg"
        }
    }


}