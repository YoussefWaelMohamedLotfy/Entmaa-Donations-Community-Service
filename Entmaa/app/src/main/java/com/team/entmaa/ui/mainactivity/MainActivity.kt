package com.team.entmaa.ui.mainactivity

import android.os.Bundle
import android.view.View
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.databinding.DataBindingUtil
import androidx.navigation.fragment.NavHostFragment
import androidx.navigation.ui.setupWithNavController
import com.google.android.material.chip.Chip
import com.google.android.material.shape.CornerFamily
import com.google.android.material.shape.MaterialShapeDrawable
import com.iammert.library.ui.multisearchviewlib.MultiSearchView
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.data.sources.remote.TagsApi
import com.team.entmaa.databinding.ActivityMainBinding
import com.team.entmaa.databinding.ItemTagBinding
import com.team.entmaa.util.BaseListAdapter
import com.team.entmaa.util.playAnimation
import dagger.hilt.android.AndroidEntryPoint
import javax.inject.Inject

@AndroidEntryPoint
class MainActivity : AppCompatActivity() {

    private lateinit var binding: ActivityMainBinding
    private val filtersViewModel:FiltersViewModel by viewModels()


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = DataBindingUtil.setContentView(this,R.layout.activity_main)

        styleBottomNavigationBar()

        setupFilters()

        setupSwipeRefreshLayout()

        setupSearch()

        (supportFragmentManager
            .findFragmentById(R.id.mainFragmentContainer)
                as NavHostFragment)
            .navController
            .addOnDestinationChangedListener { controller, destination, arguments ->

                when(destination.id)
                {
                    R.id.donateFragment,
                    R.id.volunteerFragment,
                    R.id.auctionFragment,
                    R.id.reportedItemsFragment,
                     -> {
                        showSearch()
                        showBottomNav()
                    }

                    R.id.moreFragment -> {
                        showBottomNav()
                        hideSearch()
                    }
                    else -> {
                        hideBottomNav()
                        hideSearch()
                    }
                }

            }

    }

    private fun hideBottomNav()
    {
        if(binding.bottomNavigation.visibility == View.VISIBLE)
        {
            binding.bottomNavigation.playAnimation(R.anim.slide_down_fade_out)
            binding.bottomNavigation.visibility = View.INVISIBLE
            binding.bottomNavShadow.visibility = View.INVISIBLE
        }
    }

    private fun showBottomNav()
    {
        if(binding.bottomNavigation.visibility == View.INVISIBLE)
        {
            binding.bottomNavigation.playAnimation(R.anim.slide_up_fade_in)
            binding.bottomNavigation.visibility = View.VISIBLE
            binding.bottomNavShadow.visibility = View.VISIBLE
        }
    }

    private fun hideSearch(){

        if(binding.topBar.visibility == View.VISIBLE)
        {
            binding.topBar.playAnimation(R.anim.slide_up_fade_out)
            binding.topBar.visibility = View.INVISIBLE
        }
    }

    private fun showSearch()
    {
        if(binding.topBar.visibility == View.INVISIBLE)
        {
            binding.topBar.playAnimation(R.anim.slide_down_fade_in)
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
                filtersViewModel.filterBySearch(s.toString())
            }

            override fun onSearchItemRemoved(index: Int) {
                filtersViewModel.filterBySearch("")
            }

            override fun onTextChanged(index: Int, s: CharSequence) {
            }

        })
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

        val adapter = object : BaseListAdapter<TagDto, ItemTagBinding>(R.layout.item_tag) {
            val checkedFilters = mutableSetOf<TagDto>()

            override fun ItemTagBinding.bind(item: TagDto, position: Int) {
                tag.text = item.name
                tag.setOnClickListener {
                    it as Chip

                    if (it.isChecked) {
                        checkedFilters.add(item)
                    } else {
                        checkedFilters.remove(item)
                    }

                    filtersViewModel.filterByTags(checkedFilters)
                }
            }
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