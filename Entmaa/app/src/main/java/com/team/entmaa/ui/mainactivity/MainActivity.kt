package com.team.entmaa.ui.mainactivity

import android.os.Bundle
import android.view.View
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.children
import androidx.databinding.DataBindingUtil
import androidx.navigation.fragment.NavHostFragment
import androidx.navigation.ui.setupWithNavController
import com.google.android.material.shape.CornerFamily
import com.google.android.material.shape.MaterialShapeDrawable
import com.team.entmaa.R
import com.team.entmaa.databinding.ActivityMainBinding
import com.team.entmaa.util.playAnimation
import dagger.hilt.android.AndroidEntryPoint

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

    }

    fun setupSwipeRefreshLayout()
    {
        binding.SwipeRefreshLayout.setOnRefreshListener {
            filtersViewModel.setRefreshing(true)
        }

        filtersViewModel.refreshState.observe(this){
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
                binding.filterBar.root.playAnimation(R.anim.fade_in)
                binding.filterBar.root.visibility = View.VISIBLE
            }
            else if (visibility == View.VISIBLE)
            {
                binding.filterBar.root.playAnimation(R.anim.fade_out)
                binding.filterBar.root.visibility = View.INVISIBLE
            }
        }


        binding.filterBar.exerciseChips

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