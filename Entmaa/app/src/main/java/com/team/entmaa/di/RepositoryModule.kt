package com.team.entmaa.di


import com.team.entmaa.data.repositories.implementaion.DonationRequestsRepositoryImpl
import com.team.entmaa.data.repositories.interfaces.DonationRequestsRepository
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.components.ActivityRetainedComponent
import dagger.hilt.android.scopes.ActivityRetainedScoped
import javax.inject.Qualifier


@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class FakeRepository

@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class RealRepository

@Module
@InstallIn(ActivityRetainedComponent::class)
object RepositoryModule {

    @Provides
    @ActivityRetainedScoped
    fun provideDonationRequestsRepository(donationRequestsApi: DonationRequestsApi)
    : DonationRequestsRepository
    {
        return DonationRequestsRepositoryImpl(donationRequestsApi)
    }
}