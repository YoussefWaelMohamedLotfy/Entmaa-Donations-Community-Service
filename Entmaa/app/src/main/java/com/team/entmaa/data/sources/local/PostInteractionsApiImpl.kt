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
        return mutableListOf<CommentDto>().apply {
            repeat(3){

                val comment = CommentDto().apply {
                    commentedBy = ContributorDto().apply {
                        username = "Contributor $it"
                        profilePhotoUrl = PostsPlaceholder.profilePhotoUrl + Random.nextInt()
                    }
                    commentText = "I wish you the best of luck"
                }

                add(comment)
            }
        }
    }
}