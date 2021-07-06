package com.team.entmaa.ui.commentsfragment

import android.os.Bundle
import android.view.View
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.posts.CommentDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.PostInteractionsApi
import com.team.entmaa.databinding.FragmentCommentsBinding
import com.team.entmaa.databinding.ItemCommentBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.loadURL
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject

@AndroidEntryPoint
class CommentsFragment : Fragment(R.layout.fragment_comments) {


    lateinit var binding:FragmentCommentsBinding

    @Inject lateinit var postInteractionsApi: PostInteractionsApi
    @Inject lateinit var contributor: ContributorDto

    override fun onViewCreated(view: View, savedInstanceState: Bundle?)
    {
        super.onCreate(savedInstanceState)
        binding = FragmentCommentsBinding.bind(view)

        val postId = CommentsFragmentArgs.fromBundle(requireArguments()).postId

        val adapter = BaseListAdapter<CommentDto,ItemCommentBinding>(R.layout.item_comment)
        {item,position ->

            username.text = item.commentedBy.username
            commentText.text = item.commentText
            profilePhoto.loadURL(item.commentedBy.profilePhotoUrl)
        }

        binding.commentsList.adapter = adapter


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