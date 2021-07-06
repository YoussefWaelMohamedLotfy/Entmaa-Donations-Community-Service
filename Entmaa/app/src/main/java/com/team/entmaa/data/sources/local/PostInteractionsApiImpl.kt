package com.team.entmaa.data.sources.local

import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import kotlin.random.Random

object PostInteractionsApiImpl : PostInteractionsApi {
    override suspend fun commentOnPost(postId: Int, comment: CommentDto) {

    }

    override suspend fun reactOnPost(postId: Int, userId: Int) {
    }

    override suspend fun removeReactOnPost(postId: Int, userId: Int) {
    }


    override suspend fun getComments(postId: Int): List<CommentDto> {
        return mutableListOf(
            CommentDto().apply {
                commentedBy = ContributorDto().apply {
                    username = "Omar Khaled"
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }
                commentText = "I wish you the best of luck"
            },
            CommentDto().apply {
                commentedBy = ContributorDto().apply {
                    username = "Beshoy Victor"
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }
                commentText = "Always in support of those in need"
            },
            CommentDto().apply {
                commentedBy = ContributorDto().apply {
                    username = "Mohamad Amr"
                    profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                }
                commentText = "I can definitely this is a trust worthy Organization"
            }
        )
    }
}