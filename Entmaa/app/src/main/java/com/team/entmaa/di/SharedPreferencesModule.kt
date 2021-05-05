package com.team.entmaa.di

import android.content.Context
import com.team.entmaa.R
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.android.qualifiers.ApplicationContext
import dagger.hilt.components.SingletonComponent
import javax.inject.Qualifier


@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class OrgId

@Qualifier
@Retention(AnnotationRetention.BINARY)
annotation class ContribId

@Module
@InstallIn(SingletonComponent::class)
object SharedPreferencesModule {

    @ContribId
    @Provides
    fun provideContribId(@ApplicationContext context: Context) : Int
    {
        val fileName = context.getString(R.string.GlobalSharedPreferences)
        val key = context.getString(R.string.Key_LoggedInContribId)
        return context.getSharedPreferences(fileName,Context.MODE_PRIVATE)
            .getInt(key,-1)
    }

    @OrgId
    @Provides
    fun provideOrgId(@ApplicationContext context: Context) : Int
    {
        val fileName = context.getString(R.string.GlobalSharedPreferences)
        val key = context.getString(R.string.Key_LoggedInOrgId)
        return context.getSharedPreferences(fileName,Context.MODE_PRIVATE)
            .getInt(key,-1)
    }


}