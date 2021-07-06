package com.team.entmaa.ui.eventdetails

import android.location.Address
import android.os.Bundle
import android.view.View
import android.widget.SearchView
import androidx.fragment.app.Fragment
import androidx.lifecycle.lifecycleScope
import androidx.navigation.fragment.findNavController
import com.google.android.gms.common.api.GoogleApiClient
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.Marker
import com.google.android.gms.maps.model.MarkerOptions
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.R
import com.team.entmaa.data.sources.local.EventsApiImpl
import com.team.entmaa.data.sources.remote.EventsApi
import com.team.entmaa.databinding.FragmentDetailsEventBinding
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject

@AndroidEntryPoint
class EventDetailsFragment : Fragment(R.layout.fragment_details_event) {

    @Inject
    lateinit var eventsApi: EventsApi

    lateinit var binding:FragmentDetailsEventBinding


    internal var mCurrLocationMarker: Marker? = null
    internal lateinit var mLocationRequest: LocationRequest
    internal var mGoogleApiClient: GoogleApiClient? = null
    var addressList: List<Address>? = null


    private val callback = OnMapReadyCallback { googleMap ->
        val Egypt = LatLng(30.0444196,31.2357116)
        googleMap.addMarker(MarkerOptions().position(Egypt).title("Egypt"))
        googleMap.animateCamera(CameraUpdateFactory.newLatLngZoom(Egypt, 15f))

    }



    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = FragmentDetailsEventBinding.bind(view)

        val mapFragment = childFragmentManager.findFragmentById(R.id.map) as SupportMapFragment?
        mapFragment?.getMapAsync(callback)

        viewLifecycleOwner.lifecycleScope.launch {
            val eventId = EventDetailsFragmentArgs.fromBundle(requireArguments()).eventId
            val event = (eventsApi as EventsApiImpl).getEventById(eventId)

            binding.eventName.text = event.title

            binding.createdBy.text = event.postedBy.username

            binding.detailsTxt.text = event.description

            binding.startDurationVal.text  = event.startDate.toString()

            binding.endDurationVal.text  = event.endDate.toString()

            binding.volunteerBtn.setOnClickListener {
                Snackbar.make(binding.root,"Volunteer request sent",Snackbar.LENGTH_SHORT)
                    .show()

                findNavController().navigateUp()
            }
        }
    }
}