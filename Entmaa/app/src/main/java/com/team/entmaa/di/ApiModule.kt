package com.team.entmaa.di

import com.team.entmaa.data.sources.local.*
import com.team.entmaa.data.sources.remote.*
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
    fun provideDonationRequestsApi(retrofit: Retrofit) : DonationRequestsApi
    {
        return retrofit.create(DonationRequestsApi::class.java)
    }

    @FakeApi
    @Provides
    fun provideFakeDonationRequestsApi() : DonationRequestsApi
    {
        return DonationRequestApiImpl
    }

    @Provides
    fun provideTagsApi() : TagsApi
    {
        return TagsApiImpl
    }

    @Provides
    fun providePostInteractionsApi() : PostInteractionsApi
    {
        return PostInteractionsApiImpl
    }

    @Provides
    fun provideEventsApi() : EventsApi
    {
        return EventsApiImpl
    }

    @Provides
    fun provideAuctionsApi() : AuctionApi
    {
        return AuctionApiImpl
    }

    @Provides
    fun provideReportedItemsApi() : ReportedItemsApi
    {
        return ReportedItemsApiImpl
    }

}