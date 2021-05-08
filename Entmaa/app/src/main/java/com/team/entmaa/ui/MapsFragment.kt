package com.team.entmaa.ui

import android.location.Address
import android.location.Geocoder
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.SearchView
import android.widget.Toast
import androidx.fragment.app.Fragment
import com.google.android.gms.common.api.GoogleApiClient
import com.google.android.gms.location.LocationRequest
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.Marker
import com.google.android.gms.maps.model.MarkerOptions
import com.team.entmaa.R
import java.io.IOException


class MapsFragment : Fragment() {

    internal var mCurrLocationMarker: Marker? = null
    internal lateinit var mLocationRequest: LocationRequest
    internal var mGoogleApiClient: GoogleApiClient? = null
    var addressList: List<Address>? = null


    lateinit var searchView:SearchView


    private val callback = OnMapReadyCallback { googleMap ->
        val Egypt = LatLng(30.0444196,31.2357116)
        googleMap.addMarker(MarkerOptions().position(Egypt).title("Egypt"))
        googleMap.animateCamera(CameraUpdateFactory.newLatLngZoom(Egypt, 15f))

    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val root= inflater.inflate(R.layout.fragment_maps, container, false)
        Log.i("here","onCreateView")

        searchView =  root.findViewById(R.id.searchBar)
        searchView.setOnQueryTextListener(object : SearchView.OnQueryTextListener{
            override fun onQueryTextSubmit(location: String?): Boolean {
                if (location == null || location == "") {
                    Toast.makeText(activity,"provide location",Toast.LENGTH_SHORT).show()
                }
                else {
                    val geoCoder = Geocoder(activity)
                    try {
                        addressList = geoCoder.getFromLocationName(location, 1)

                    } catch (e: IOException) {
                        e.printStackTrace()
                    }

                    if(addressList==null || addressList!!.isEmpty()) {
                        Toast.makeText(activity,"Please rewrite the location correctly ;)",Toast.LENGTH_SHORT).show()
                        return false
                    }
                    val address = addressList!![0]
                    val latLng = LatLng(address.latitude, address.longitude)

                    Log.i("map","here")
                    val mapFragment = childFragmentManager.findFragmentById(R.id.map) as SupportMapFragment?
                    mapFragment?.getMapAsync { googleMap ->
                        googleMap.clear()
                        googleMap.addMarker(MarkerOptions().position(latLng).title(location))
                        googleMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng, 15f))
                    }
                }
                return false
            }
            override fun onQueryTextChange(newText: String?): Boolean {
                return false;

            }
        })

        return  root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        Log.i("here","onViewCreated")

        super.onViewCreated(view, savedInstanceState)
        val mapFragment = childFragmentManager.findFragmentById(R.id.map) as SupportMapFragment?
        mapFragment?.getMapAsync(callback)
    }




}