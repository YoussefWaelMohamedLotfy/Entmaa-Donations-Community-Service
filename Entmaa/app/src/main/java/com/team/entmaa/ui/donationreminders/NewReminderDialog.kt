package com.team.entmaa.ui.donationreminders

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.viewModels
import com.google.android.material.bottomsheet.BottomSheetDialogFragment
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.subscriptions.SubscriptionDto
import com.team.entmaa.databinding.DialogNewDonateditemBinding
import com.team.entmaa.databinding.DialogNewReminderBinding
import com.team.entmaa.ui.orgselector.OrgSelectorViewModel
import dagger.hilt.android.AndroidEntryPoint

@AndroidEntryPoint
class NewReminderDialog : BottomSheetDialogFragment(){

    val remindersViewModel:RemindersViewModel by viewModels({requireParentFragment()})

    val orgSelectorViewModel:OrgSelectorViewModel by viewModels()

    lateinit var binding:DialogNewReminderBinding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {

        return inflater.inflate(R.layout.dialog_new_reminder,container,false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        binding = DialogNewReminderBinding.bind(view)

        binding.addBtn.setOnClickListener {
            val sub = SubscriptionDto().apply {
                name = binding.reminderName.editText?.text.toString()
                intervalInDays = binding.reminderFrequency.editText?.text.toString().toInt()
                moneyAmount = binding.moneyToDonate.editText?.text.toString().toInt()
                subscribedTo = orgSelectorViewModel.selectedOrganization.value?.id!!
            }

            remindersViewModel.addNewSubscription(sub)
            dismiss()
        }
    }
}