package com.team.entmaa.ui.contribdonateditems

import android.net.Uri
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.activity.result.contract.ActivityResultContracts
import androidx.fragment.app.viewModels
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.StaggeredGridLayoutManager
import com.google.android.material.bottomsheet.BottomSheetDialogFragment
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.donations.DonatedItemDto
import com.team.entmaa.data.sources.remote.TagsApi
import com.team.entmaa.databinding.DialogNewDonateditemBinding
import com.team.entmaa.ui.tags.TagsAdapter
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject

@AndroidEntryPoint
class DonatedItemDialog : BottomSheetDialogFragment() {


    lateinit var binding:DialogNewDonateditemBinding

    private val donatedItemsViewModel:DonatedItemsViewModel by viewModels({requireParentFragment()})

    @Inject
    lateinit var tagsApi: TagsApi

    override fun onCreateView(inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?): View {
        return inflater.inflate(R.layout.dialog_new_donateditem, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = DialogNewDonateditemBinding.bind(view)


        val adapter = TagsAdapter{ tagDto, isChecked, selectedTags ->

        }

        lifecycleScope.launch {
            adapter.submitList(tagsApi.getAllTags().toList())
        }

        var selectedImageUri:String =""
        val getPhoto = registerForActivityResult(ActivityResultContracts.GetContent()) { uri: Uri? ->
            uri?.let {
                binding.itemPic.setImageURI(uri)
                selectedImageUri = uri.toString()
            }
        }

        binding.itemPic.setOnClickListener {
            getPhoto.launch("image/*")
        }

        binding.categoriesMenu.adapter = adapter

        binding.donatedItemAddBut.setOnClickListener {
            val item = DonatedItemDto().apply {
                itemName = binding.itemName.editText?.text.toString()
                description = binding.itemDescription.editText?.text.toString()
                tags = adapter.checkedFilters.toList()
                photoUrl = selectedImageUri
            }

            donatedItemsViewModel.addItemForDonation(item)
            dismiss()
        }
    }
}