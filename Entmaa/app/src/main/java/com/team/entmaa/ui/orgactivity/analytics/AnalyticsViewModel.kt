package com.team.entmaa.ui.orgactivity.analytics

import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

import com.team.entmaa.data.model.dto.analytics.OrgAnalytics
import java.text.DateFormatSymbols
import java.time.LocalDate
import kotlin.random.Random
import kotlin.random.nextInt

class AnalyticsViewModel : ViewModel() {

    val monthNames = DateFormatSymbols().months.toList()

    private val mAllMonthAnalytics: MutableList<OrgAnalytics> = mutableListOf()

    private val mSelectedMonthAnalytics = MutableLiveData<OrgAnalytics>()
    val selectedMonthAnalytics:LiveData<OrgAnalytics> = mSelectedMonthAnalytics

    var selectedMonthIndex = 0
    private set

    init {
        getAnalytics()
        changeMonth(LocalDate.now().monthValue - 1)

    }


    fun changeMonth(index:Int)
    {
        selectedMonthIndex = index
        mSelectedMonthAnalytics.value = mAllMonthAnalytics[index]
    }

    private fun getAnalytics()
    {
        repeat(monthNames.size)
        {
            val valuesRange = 2..20

            val moneyTarget = Random.nextInt(1000..5000)
            val moneyReceived = Random.nextInt(100..moneyTarget)
            mAllMonthAnalytics.add(
               OrgAnalytics(
                   moneyDonationsCount = Random.nextInt(valuesRange),
                   itemDonationsCount = Random.nextInt(valuesRange),
                   peopleVolunteered =Random.nextInt(valuesRange),
                   auctionItemsSold = Random.nextInt(valuesRange),
                   targetMoney = moneyTarget,
                   moneyReceived = moneyReceived,
                   commentsReceived = Random.nextInt(valuesRange),
                   reactsReceived = Random.nextInt(valuesRange),
                   newFollowers = Random.nextInt(valuesRange),
               )
            )



        }
    }
}