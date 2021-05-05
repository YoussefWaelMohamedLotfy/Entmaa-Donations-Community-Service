package com.team.entmaa.di

import com.squareup.moshi.Moshi
import com.team.entmaa.util.moshi.LocalDateConverter
import com.team.entmaa.util.moshi.ZonedDateTimeConverter
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.components.SingletonComponent
import javax.inject.Singleton


@Module
@InstallIn(SingletonComponent::class)
object MoshiModule {

    @Provides
    @Singleton
    fun provideMoshi() : Moshi
    {
        return Moshi.Builder()
            .add(ZonedDateTimeConverter())
            .add(LocalDateConverter())
            .build()
    }
}