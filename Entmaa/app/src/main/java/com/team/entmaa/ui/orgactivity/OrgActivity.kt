package com.team.entmaa.ui.orgactivity

import android.os.Bundle
import android.view.View
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.content.res.AppCompatResources
import androidx.appcompat.widget.AppCompatImageView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.databinding.DataBindingUtil
import androidx.navigation.fragment.NavHostFragment
import androidx.navigation.ui.setupWithNavController
import com.google.android.material.shape.CornerFamily
import com.google.android.material.shape.MaterialShapeDrawable
import com.iammert.library.ui.multisearchviewlib.MultiSearchView
import com.team.entmaa.R
import com.team.entmaa.databinding.ActivityMainOrgBinding
import com.team.entmaa.ui.filters.FiltersViewModel
import com.team.entmaa.ui.tags.TagsAdapter
import com.team.entmaa.util.playAnimation
import dagger.hilt.android.AndroidEntryPoint


@AndroidEntryPoint
class OrgActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainOrgBinding
    private val filtersViewModel: FiltersViewModel by viewModels()


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = DataBindingUtil.setContentView(this,R.layout.activity_main_org)

        styleBottomNavigationBar()

        setupFilters()

        setupSwipeRefreshLayout()

        setupSearch()

        setUpOnDestinationChangedListener()

    }


    private fun setUpOnDestinationChangedListener()
    {
        (supportFragmentManager
            .findFragmentById(R.id.mainFragmentContainer)
                as NavHostFragment)
            .navController
            .addOnDestinationChangedListener { controller, destination, arguments ->

                when(destination.id)
                {
                    R.id.browseItemsFragment,
                    -> {
                        showSearch()
                        showBottomNav()
                        setCanRefresh(true)
                    }

                    R.id.orgDashFragment,
                    R.id.analyticsFragment
                    -> {
                        showBottomNav()
                        hideSearch()
                        setCanRefresh(false)
                    }
                    else -> {
                        hideBottomNav()
                        hideSearch()
                        setCanRefresh(false)
                    }
                }

            }
    }

    fun setCanRefresh(canRefresh:Boolean)
    {
        binding.SwipeRefreshLayout.isEnabled = canRefresh
    }

    private fun hideBottomNav()
    {
        if(binding.bottomNavigation.visibility == View.VISIBLE)
        {
            binding.bottomNavigation.playAnimation(R.anim.slide_down_fade_out)
            binding.bottomNavShadow.playAnimation(R.anim.slide_down_fade_out)
            binding.bottomNavigation.visibility = View.INVISIBLE
            binding.bottomNavShadow.visibility = View.INVISIBLE
        }
    }

    private fun showBottomNav()
    {
        if(binding.bottomNavigation.visibility == View.INVISIBLE)
        {
            binding.bottomNavigation.playAnimation(R.anim.slide_up_fade_in)
            binding.bottomNavShadow.playAnimation(R.anim.slide_up_fade_in)
            binding.bottomNavigation.visibility = View.VISIBLE
            binding.bottomNavShadow.visibility = View.VISIBLE
        }
    }

    private fun hideSearch(){

        if(binding.topBar.visibility == View.VISIBLE)
        {
            val addMargin = ConstraintLayout
                .LayoutParams(ConstraintLayout.LayoutParams.MATCH_PARENT,ConstraintLayout.LayoutParams.MATCH_PARENT)
                .apply {
                    val top = resources.getDimension(R.dimen.search_bar_height).toInt()
                    topMargin = 0
                }
            binding.SwipeRefreshLayout.layoutParams = addMargin
            binding.SwipeRefreshLayout.requestLayout()
            binding.topBar.playAnimation(R.anim.fade_out)
            binding.topBar.visibility = View.INVISIBLE
        }
    }

    private fun showSearch()
    {
        if(binding.topBar.visibility == View.INVISIBLE)
        {
            val addMargin = ConstraintLayout
                .LayoutParams(ConstraintLayout.LayoutParams.MATCH_PARENT,ConstraintLayout.LayoutParams.MATCH_PARENT)
                .apply {
                    val top = resources.getDimension(R.dimen.search_bar_height).toInt()
                topMargin = top
            }
            println("Show ")
            binding.SwipeRefreshLayout.layoutParams = addMargin
            binding.SwipeRefreshLayout.requestLayout()
            binding.topBar.playAnimation(R.anim.fade_in)
            binding.topBar.visibility = View.VISIBLE
        }
    }

    fun setupSearch()
    {
        binding.searchBar.setSearchViewListener(object : MultiSearchView.MultiSearchViewListener{
            override fun onItemSelected(index: Int, s: CharSequence) {
                filtersViewModel.filterBySearch(s.toString())
            }

            override fun onSearchComplete(index: Int, s: CharSequence) {
                if(s.isNotEmpty())
                {
                    filtersViewModel.filterBySearch(s.toString())
                }
            }

            override fun onSearchItemRemoved(index: Int) {
                filtersViewModel.filterBySearch("")
            }

            override fun onTextChanged(index: Int, s: CharSequence) {
            }

        })

        val searchIcon = findViewById<AppCompatImageView>(R.id.imageViewSearch).apply {
            //@color/mtrl_text_btn_text_color_selector
            imageTintList = AppCompatResources.getColorStateList(context,R.color.material_on_background_emphasis_medium)
        }

    }

    private fun setupSwipeRefreshLayout()
    {
        binding.SwipeRefreshLayout.setOnRefreshListener {
            filtersViewModel.userRequestedRefresh()
        }

        filtersViewModel.requestTriggeredRefresh.observe(this){
            binding.SwipeRefreshLayout.isRefreshing = it
        }
    }

    private fun setupFilters()
    {

        binding.filterBar.root.visibility = View.INVISIBLE

        binding.filterBtn.setOnClickListener {
            val visibility = binding.filterBar.root.visibility
            if(visibility == View.INVISIBLE)
            {
                binding.filterBar.root.playAnimation(R.anim.slide_up_fade_in)
                binding.filterBar.root.visibility = View.VISIBLE
            }
            else if (visibility == View.VISIBLE)
            {
                binding.filterBar.root.playAnimation(R.anim.slide_down_fade_out)
                binding.filterBar.root.visibility = View.INVISIBLE
            }
        }


        val adapter = TagsAdapter{ tagDto, isChecked, selectedTags ->
            filtersViewModel.filterByTags(selectedTags)
        }

        binding.filterBar.filterChips.adapter = adapter

        filtersViewModel.filters.observe(this){
            adapter.submitList(it.toList())
        }

    }

    private fun styleBottomNavigationBar()
    {
        val bottomNavigationDrawable = binding.bottomNavigation.background as MaterialShapeDrawable
        val radius = resources.getDimension(R.dimen.bottom_nav_radius)
        bottomNavigationDrawable.apply {
            shapeAppearanceModel = shapeAppearanceModel.toBuilder()
                .setTopRightCorner(CornerFamily.ROUNDED, radius)
                .setTopLeftCorner(CornerFamily.ROUNDED, radius)
                .build()

        }

        val navHostFragment =
            supportFragmentManager.findFragmentById(R.id.mainFragmentContainer) as NavHostFragment
        val navController = navHostFragment.navController

        binding.bottomNavigation.setupWithNavController(navController)

    }
}