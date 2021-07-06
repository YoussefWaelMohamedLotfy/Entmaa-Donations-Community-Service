package com.team.entmaa.ui.reportedcase

import android.net.Uri
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.activity.result.contract.ActivityResultContracts
import androidx.lifecycle.lifecycleScope
import com.google.android.material.bottomsheet.BottomSheetDialogFragment
import com.google.android.material.snackbar.Snackbar
import com.team.entmaa.R
import com.team.entmaa.data.sources.remote.TagsApi
import com.team.entmaa.databinding.DialogReportCaseBinding
import com.team.entmaa.ui.tags.TagsAdapter
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch
import javax.inject.Inject


@AndroidEntryPoint
class ReportCaseDialog : BottomSheetDialogFragment() {

    lateinit var binding:DialogReportCaseBinding


    @Inject
    lateinit var tagsApi: TagsApi

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.dialog_report_case,container,false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = DialogReportCaseBinding.bind(view)

        val getPhoto = registerForActivityResult(ActivityResultContracts.GetContent()) { uri: Uri? ->
            uri?.let {
                binding.casePhoto.setImageURI(uri)
            }
        }

        binding.casePhoto.setOnClickListener {
            getPhoto.launch("image/*")
        }


        val adapter = TagsAdapter{ tagDto, isChecked, selectedTags ->

        }

        lifecycleScope.launch {
            adapter.submitList(tagsApi.getAllTags().toList())
        }

        binding.tagsList.adapter = adapter


        binding.reportBtn.setOnClickListener {
            Snackbar.make(requireParentFragment().requireView(),"Case Reported",Snackbar.LENGTH_SHORT)
                .show()

            dismiss()
        }
    }
}