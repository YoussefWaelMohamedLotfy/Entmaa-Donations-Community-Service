package com.team.entmaa.ui.mainactivity.donatefragment


import com.team.entmaa.R
import com.team.entmaa.data.model.domain.DonationRequest
import com.team.entmaa.databinding.ItemDonationRequestBinding


import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.loadURL


class DonationRequestsAdapter :
    BaseListAdapter<DonationRequest, ItemDonationRequestBinding>(R.layout.item_donation_request)
{
    override fun ItemDonationRequestBinding.bind(item: DonationRequest, position: Int) {
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


