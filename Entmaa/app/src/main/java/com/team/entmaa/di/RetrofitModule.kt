package com.team.entmaa.di

import com.skydoves.sandwich.coroutines.CoroutinesResponseCallAdapterFactory
import com.squareup.moshi.Moshi
import dagger.Module
import dagger.Provides
import dagger.hilt.InstallIn
import dagger.hilt.components.SingletonComponent
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory
import javax.inject.Singleton





@Module
@InstallIn(SingletonComponent::class)
object RetrofitModule {


    const val baseURl = "https://f037a326-3d6a-4ece-bf1a-85c4fd22a377.mock.pstmn.io/"

    @Provides
    @Singleton
    fun provideRetrofit(moshi: Moshi) : Retrofit
    {
        return Retrofit.Builder()
            .baseUrl(baseURl)
            .addConverterFactory(MoshiConverterFactory.create(moshi))
            .addCallAdapterFactory(CoroutinesResponseCallAdapterFactory())
            .build()
    }

}