package com.team.entmaa.ui.donationreminders

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.viewModels
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.subscriptions.SubscriptionDto
import com.team.entmaa.databinding.FragmentSubscriptionsBinding
import com.team.entmaa.databinding.ItemSubscriptionBinding
import com.team.entmaa.util.BaseListAdapter
import dagger.hilt.android.AndroidEntryPoint


@AndroidEntryPoint
class SubscriptionsFragment : Fragment(R.layout.fragment_subscriptions) {

    lateinit var binding:FragmentSubscriptionsBinding

    val remindersViewModel:RemindersViewModel by viewModels()

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentSubscriptionsBinding.bind(view)

        binding.addSubscriptionBtn.setOnClickListener {
            NewReminderDialog().show(childFragmentManager,"")
        }

        val adapter = BaseListAdapter<SubscriptionDto,ItemSubscriptionBinding>(R.layout.item_subscription)
        { item, position ->
            subscriptionName.text = item.name
            frequency.text = item.intervalInDays.toString()
            renewalDate.text = item.startDate.plusDays(item.intervalInDays.toLong()).toString()
            moneyToDonate.text = item.moneyAmount.toString()
        }

        remindersViewModel.mySubscriptions.observe(viewLifecycleOwner)
        {
            adapter.submitList(it)
        }

        remindersViewModel.addedSubscription.observe(viewLifecycleOwner){
            adapter.add(it)
        }

        binding.subsRecyclerView.adapter = adapter
    }


}