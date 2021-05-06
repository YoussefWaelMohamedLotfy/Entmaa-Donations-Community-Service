package com.team.entmaa.ui.commentsactivity

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ListAdapter
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.users.UserDto
import com.team.entmaa.databinding.ActivityCommentsBinding
import com.team.entmaa.databinding.ItemCommentBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.FakePosts
import com.team.entmaa.util.loadURL
import kotlin.random.Random

class CommentsActivity : AppCompatActivity() {

    lateinit var binding:ActivityCommentsBinding

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCommentsBinding.inflate(layoutInflater)
        setContentView(binding.root)


        val adapter = BaseListAdapter<CommentDto,ItemCommentBinding>(R.layout.item_comment)
        {item,position ->

            username.text = item.commentedBy?.username
            commentText.text = item.commentText
            profilePhoto.loadURL(item.commentedBy?.profilePhotoUrl!!)
        }

        binding.commentsList.adapter = adapter

        val list = mutableListOf<CommentDto>().apply{

            repeat(20)
            {
                val comment = CommentDto().apply {
                    commentedBy = UserDto().apply {
                        username = "My Name"
                        profilePhotoUrl = FakePosts.profilePhotoUrl + Random.nextInt()
                    }

                    commentText = "dhgfjaosdhfglkjasdhfkjl"
                }

                add(comment)
            }

        }

        adapter.submitList(list)
    }
}