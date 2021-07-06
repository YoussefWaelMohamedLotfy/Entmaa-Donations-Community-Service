package com.team.entmaa.util.MPAndroidChart

import android.graphics.Color
import android.graphics.Typeface
import android.icu.text.DecimalFormat
import android.os.Build
import android.view.LayoutInflater
import androidx.annotation.RequiresApi
import com.github.mikephil.charting.animation.Easing
import com.github.mikephil.charting.charts.PieChart
import com.github.mikephil.charting.data.PieData
import com.github.mikephil.charting.data.PieDataSet
import com.github.mikephil.charting.data.PieEntry
import com.github.mikephil.charting.formatter.ValueFormatter
import com.team.entmaa.R
import com.team.entmaa.databinding.AnalyticsChartBinding
import com.team.entmaa.databinding.PiechartLegendItemBinding


//fun PieChart.bind(expensesReport: ExpensesReport)
//{
//    val entries: MutableList<PieEntry> = ArrayList()
//    entries.add(PieEntry(expensesReport.income.toFloat(), ""))
//    entries.add(PieEntry(expensesReport.expenses.toFloat(), ""))
//
//    val set = PieDataSet(entries, "Expenses report").apply {
//        colors = context.resources.getIntArray(R.array.pieChartColors).toList()
//        //setEntryLabelTextSize(10f)
//        this.valueTextColor = this@bind.context.getColorStateList(R.color.color_on_surface_alpha_70).defaultColor
//        this.valueTextSize = 0f
//        valueFormatter = object : ValueFormatter() {
//            @RequiresApi(Build.VERSION_CODES.N)
//            override fun getPieLabel(value: Float, pieEntry: PieEntry?): String {
//                return "${DecimalFormat("#.##").format(value)}%"
//            }
//        }
//    }
//
//    val chartData = PieData(set)
//
//    this.apply {
//        description.isEnabled = false
//        data = chartData
//        this.setEntryLabelColor(this@bind.context.getColor(R.color.offWhite_200))
//        legend.isEnabled = false
//        this.transparentCircleRadius = 0f
//        setTouchEnabled(false)
//        setUsePercentValues(true)
//        invalidate()
//    }
//}

fun PieChart.addEntriesWithLines(addEntries: MutableList<PieEntry>.() -> Unit)
{
    val entries: MutableList<PieEntry> = ArrayList()

    entries.addEntries()

    val context = this.context

    val set = PieDataSet(entries, "Expenses report").apply {

        colors = context.resources.getIntArray(R.array.pieChartColors).toList()
        //setEntryLabelTextSize(10f)
        //this.valueTextColor = context.getColor(R.color.offWhite_200)
        this.valueTextSize = 12f
        valueFormatter = object : ValueFormatter() {
            @RequiresApi(Build.VERSION_CODES.N)
            override fun getPieLabel(value: Float, pieEntry: PieEntry?): String {
                return "${DecimalFormat("#.##").format(value)}%"
            }
        }

        this.isUsingSliceColorAsValueLineColor = true
        this.isValueLineVariableLength = true
        valueLinePart1OffsetPercentage = 10f
        valueLinePart1Length = 1f
        valueLinePart2Length = 0.4f
        valueTextColor = Color.BLACK
        xValuePosition = PieDataSet.ValuePosition.OUTSIDE_SLICE
        yValuePosition = PieDataSet.ValuePosition.OUTSIDE_SLICE
        //Log.d("fsadf", "addEntriesWithLines: ")
        this.selectionShift = 50f

    }

    val chartData = PieData(set)

    this.apply {
        description.isEnabled = false
        centerText = "%"
        data = chartData
        setCenterTextSize(20f)
        this.transparentCircleRadius = 0f
        this.setEntryLabelColor(Color.BLACK)
        this.setEntryLabelTextSize(12f)
        this.setEntryLabelTypeface(Typeface.DEFAULT_BOLD)
        legend.isEnabled = false
        isHighlightPerTapEnabled = false
        //setTouchEnabled(false)
        setUsePercentValues(true)

        invalidate()
    }
}


fun PieChart.addEntriesChartOnly(entries: List<PieEntry>)
{

    val context = this.context

    val set = PieDataSet(entries, "").apply {

        colors = context.resources.getIntArray(R.array.pieChartColors).toList()
        setDrawValues(false)
        valueFormatter = object : ValueFormatter() {
            @RequiresApi(Build.VERSION_CODES.N)
            override fun getPieLabel(value: Float, pieEntry: PieEntry?): String {
                return "${DecimalFormat("#.##").format(value)}%"
            }

        }
    }

    val chartData = PieData(set)

    this.apply {
        description.isEnabled = false
        data = chartData
        setDrawEntryLabels(false)
        legend.isEnabled = false
        holeRadius = 75f
        transparentCircleRadius = 0f
        isHighlightPerTapEnabled = false
        //setTouchEnabled(false)
        setUsePercentValues(true)
        invalidate()
    }
}

fun AnalyticsChartBinding.bind(label:String, addEntries: MutableList<PieEntry>.() -> Unit) {

    val entries = mutableListOf<PieEntry>()
    entries.addEntries()
    val total = entries.totalSum()
    analyticsChart.addEntriesChartOnly(entries)
    val colors = analyticsChart.data.colors

    val inflater = LayoutInflater.from(this.root.context)

    chartLegend.removeAllViewsInLayout()

    chartTotal.text = total.toInt().toString()
    chartLabel.text = label


    for (i in entries.indices)
    {
        val legendEntry = PiechartLegendItemBinding.inflate(inflater,chartLegend,true)
        legendEntry.legendLabel.text = entries[i].label
        val percentage = (entries[i].value/total) * 100
        val rounded = DecimalFormat("#.##").format(percentage)
        legendEntry.legendValue.text = "$rounded%"
        legendEntry.legendMarker.setBackgroundColor(colors[i % colors.size])

    }

    analyticsChart.animateXY(500,500)

}

fun AnalyticsChartBinding.bindMoney(label:String, addEntries: MutableList<PieEntry>.() -> Unit) {

    this.bind(label,addEntries)

    val received = analyticsChart.data.dataSet.getEntryForIndex(0).value.toInt()
    val remaining = analyticsChart.data.dataSet.getEntryForIndex(1).value.toInt()
    val target = received + remaining
    chartTotal.text = "$received/\n$target"

    analyticsChart.animateXY(500,500)

}


fun AnalyticsChartBinding.bindNonPercent(label:String, addEntries: MutableList<PieEntry>.() -> Unit) {

    val entries = mutableListOf<PieEntry>()
    entries.addEntries()
    val total = entries.totalSum().toInt()
    analyticsChart.addEntriesChartOnly(entries)

    val colors = analyticsChart.data.colors

    val inflater = LayoutInflater.from(this.root.context)

    chartLegend.removeAllViewsInLayout()

    chartTotal.text = total.toString()
    chartLabel.text = label


    for (i in entries.indices)
    {
        val legendEntry = PiechartLegendItemBinding.inflate(inflater,chartLegend,true)
        legendEntry.legendLabel.text = entries[i].label
        legendEntry.legendValue.text = entries[i].value.toInt().toString()
        legendEntry.legendMarker.setBackgroundColor(colors[i % colors.size])

    }

    analyticsChart.animateXY(500,500)

}

fun Collection<PieEntry>.totalSum() : Float
{
    return this.sumByDouble { it.value.toDouble() }.toFloat()
}


