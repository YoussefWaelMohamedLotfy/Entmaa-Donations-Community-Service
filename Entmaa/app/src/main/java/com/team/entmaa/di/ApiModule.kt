package com.team.entmaa.di

import com.team.entmaa.data.sources.remote.DonatonRequestsApi
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.components.ActivityRetainedComponent
import retrofit2.Retrofit


@Module
@InstallIn(ActivityRetainedComponent::class)
class ApiModule {

    @Provides
    fun provideDonationRequestsApi(retrofit: Retrofit) : DonatonRequestsApi
    {
        return retrofit.create(DonatonRequestsApi::class.java)
    }

}