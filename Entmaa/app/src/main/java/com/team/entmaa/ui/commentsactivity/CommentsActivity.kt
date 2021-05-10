package com.team.entmaa.ui.commentsactivity

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.lifecycle.lifecycleScope
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import com.team.entmaa.databinding.ActivityCommentsBinding
import com.team.entmaa.databinding.ItemCommentBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject

@AndroidEntryPoint
class CommentsActivity : AppCompatActivity() {

    companion object{

        const val postIdKey = "postIdKey"

    }

    lateinit var binding:ActivityCommentsBinding

    @Inject lateinit var postInteractionsApi: PostInteractionsApi
    @Inject lateinit var contributor: ContributorDto

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCommentsBinding.inflate(layoutInflater)
        setContentView(binding.root)


        val adapter = BaseListAdapter<CommentDto,ItemCommentBinding>(R.layout.item_comment)
        {item,position ->

            username.text = item.commentedBy.username
            commentText.text = item.commentText
            profilePhoto.loadURL(item.commentedBy.profilePhotoUrl)
        }

        binding.commentsList.adapter = adapter

        val postId = intent.getIntExtra(postIdKey,-1)

        lifecycleScope.launch {
            adapter.submitList(postInteractionsApi.getComments(postId))
        }



        binding.sendBtn.setOnClickListener {

            val commentText = binding.commentText.text.toString()
            val comment = CommentDto().apply {
                commentedBy = contributor
                this.commentText = commentText
            }

            lifecycleScope.launch {
                postInteractionsApi.commentOnPost(postId,comment)
            }

            adapter.add(comment)

            binding.commentText.text.clear()
        }
    }
}