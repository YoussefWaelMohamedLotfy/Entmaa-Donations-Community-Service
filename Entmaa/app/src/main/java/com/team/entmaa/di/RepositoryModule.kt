package com.team.entmaa.di

import com.team.entmaa.data.repositories.IRepository
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.components.SingletonComponent
import javax.inject.Qualifier
import javax.inject.Singleton


@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class FakeRepository

@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class RealRepository

@Module
@InstallIn(SingletonComponent::class)
class RepositoryModule {

    @Provides
    @Singleton
    @FakeRepository
    fun provideRepository() : IRepository
    {
        return com.team.entmaa.data.repositories.FakeRepository
    }
}