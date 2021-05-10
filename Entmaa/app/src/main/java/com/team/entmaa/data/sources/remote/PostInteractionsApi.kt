package com.team.entmaa.data.sources.remote

import com.skydoves.sandwich.ApiResponse
import com.team.entmaa.data.model.dto.posts.CommentDto
import retrofit2.http.*

interface PostInteractionsApi {

    @POST("posts/{postId}/comments")
    suspend fun commentOnPost(@Path("postId") postId:Int,@Body comment:CommentDto)

    @POST("posts/{postId}/reacts/{userid}")
    suspend fun reactOnPost(@Path("postId") postId:Int,@Path("userid") userId:Int)

    @DELETE("posts/{postId}/reacts/{userid}")
    suspend fun removeReactOnPost(@Path("postId") postId:Int,@Path("userid") userId:Int)

    @GET("posts/{postId}/comments")
    suspend fun getComments(@Path("postId") postId:Int) : List<CommentDto>

}