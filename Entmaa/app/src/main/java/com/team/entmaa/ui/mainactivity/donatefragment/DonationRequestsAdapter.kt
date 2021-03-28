package com.team.entmaa.ui.mainactivity.donatefragment

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView
import com.team.entmaa.data.model.domain.DonationRequest
import com.team.entmaa.databinding.ItemDonationRequestBinding
import com.team.entmaa.util.BindableViewHolder
import com.team.entmaa.util.ViewHolderCreator
import com.team.entmaa.util.loadURL

class DonationRequestsAdapter :
    ListAdapter<DonationRequest, DonationRequestsAdapter.DonationRequestViewHolder>(ItemsDiffer) {

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): DonationRequestViewHolder {
        return DonationRequestViewHolder.from(parent)
    }

    override fun onBindViewHolder(holder: DonationRequestViewHolder, position: Int) {
        holder.bind(getItem(position))
    }


    class DonationRequestViewHolder private constructor(private val binding: ItemDonationRequestBinding)
        : RecyclerView.ViewHolder(binding.root), BindableViewHolder<DonationRequest>
    {
        companion object : ViewHolderCreator<DonationRequestViewHolder>{

            override fun from(parent: ViewGroup): DonationRequestViewHolder {
                val inflater = LayoutInflater.from(parent.context)
                val inflatedBinding = ItemDonationRequestBinding.inflate(inflater,parent,false)
                return DonationRequestViewHolder(inflatedBinding)
            }

        }

        override fun bind(item: DonationRequest) {

            binding.apply {
                postTitle.text = item.title
                postedBy.text = item.organizationName
                timePosted.text = "3:00 PM"
                postBody.text = item.bodyText
                posterPhoto.loadURL(item.profilePhotoURL)
                postPhoto.loadURL(item.postPhotoURL)
                donationProgress.max = item.moneyTarget
                donationProgress.progress = item.moneyCollected
                currency.text = item.currency
                moneyTarget.text = item.moneyTarget.toString()
                moneyCollected.text = item.moneyCollected.toString()
                heartButton.text = item.loveNumber.toString()
                commentsButton.text = item.commentsNumber.toString()

            }
        }

    }

    companion object {

        object ItemsDiffer : DiffUtil.ItemCallback<DonationRequest>() {
            override fun areItemsTheSame(
                oldItem: DonationRequest,
                newItem: DonationRequest
            ): Boolean {
                return oldItem == newItem
            }

            override fun areContentsTheSame(
                oldItem: DonationRequest,
                newItem: DonationRequest
            ): Boolean {
                return oldItem == newItem
            }

        }

    }
}