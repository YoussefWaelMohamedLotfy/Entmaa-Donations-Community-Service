package com.team.entmaa.di

import com.team.entmaa.data.sources.local.FakeDonationRequestApi
import com.team.entmaa.data.sources.remote.DonatonRequestsApi
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.components.ActivityRetainedComponent
import retrofit2.Retrofit
import javax.inject.Qualifier

@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class FakeApi

@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class RealApi


@Module
@InstallIn(ActivityRetainedComponent::class)
class ApiModule {

    @RealApi
    @Provides
    fun provideDonationRequestsApi(retrofit: Retrofit) : DonatonRequestsApi
    {
        return retrofit.create(DonatonRequestsApi::class.java)
    }

    @FakeApi
    @Provides
    fun provideFakeDonationRequestsApi() : DonatonRequestsApi
    {
        return FakeDonationRequestApi
    }

}