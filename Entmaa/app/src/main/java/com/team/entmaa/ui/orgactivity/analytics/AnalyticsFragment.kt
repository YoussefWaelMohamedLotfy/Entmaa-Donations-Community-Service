package com.team.entmaa.ui.orgactivity.analytics

import android.os.Bundle
import android.os.Handler
import android.os.Looper
import androidx.fragment.app.Fragment
import android.view.View
import androidx.fragment.app.viewModels
import androidx.viewpager2.widget.ViewPager2
import com.team.entmaa.util.MPAndroidChart.bind
import com.github.mikephil.charting.data.PieEntry
import com.team.entmaa.R
import com.team.entmaa.databinding.FragmentAnalyticsBinding
import com.team.entmaa.util.MPAndroidChart.bindMoney
import com.team.entmaa.util.MPAndroidChart.bindNonPercent

class AnalyticsFragment : Fragment(R.layout.fragment_analytics) {


    lateinit var binding:FragmentAnalyticsBinding

    val analyticsViewModel:AnalyticsViewModel by viewModels()

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentAnalyticsBinding.bind(view)
        setupAnalyticsObserver()
        setupMonthSelector()


    }

    private fun setupAnalyticsObserver()
    {
        analyticsViewModel.selectedMonthAnalytics.observe(viewLifecycleOwner)
        {
            binding.summaryChart.bindNonPercent("Actions"){
                add(PieEntry(it.moneyDonationsCount.toFloat(),"Money donations"))
                add(PieEntry(it.itemDonationsCount.toFloat(),"Item donations"))
                add(PieEntry(it.peopleVolunteered.toFloat(),"Volunteers"))
                add(PieEntry(it.auctionItemsSold.toFloat(),"Auction items sold"))
            }

            binding.moneyReceivedChart.bindMoney("Money Received")
            {
                add(PieEntry(it.moneyReceived.toFloat(),"Money received"))
                val remaining = it.targetMoney - it.moneyReceived
                add(PieEntry(remaining.toFloat(),"remaining"))
            }

            binding.reactCount.text = it.reactsReceived.toString()
            binding.followersCount.text = it.newFollowers.toString()
            binding.commentsCount.text = it.commentsReceived.toString()

        }
    }

    private fun setupMonthSelector()
    {
        binding.monthPager.adapter = MonthPagerAdapter().apply {
            submitList(analyticsViewModel.monthNames)
        }

        binding.previousMonth.setOnClickListener {
            binding.monthPager.previousPage()
        }

        binding.nextMonth.setOnClickListener {
            binding.monthPager.nextPage()
        }

        binding.monthPager.currentItem = analyticsViewModel.selectedMonthIndex

        binding.monthPager.registerOnPageChangeCallback(
            object : ViewPager2.OnPageChangeCallback(){
                override fun onPageSelected(position: Int) {
                    Handler(Looper.getMainLooper()).post {
                        analyticsViewModel.changeMonth(position)
                    }
                }
            }
        )
    }

}