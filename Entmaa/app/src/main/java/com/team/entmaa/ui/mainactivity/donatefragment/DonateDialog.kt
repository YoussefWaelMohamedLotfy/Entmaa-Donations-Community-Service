package com.team.entmaa.ui.mainactivity.donatefragment

import android.content.DialogInterface
import android.graphics.Color
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.core.os.bundleOf
import androidx.fragment.app.setFragmentResult
import androidx.fragment.app.viewModels
import androidx.lifecycle.lifecycleScope
import com.google.android.material.bottomsheet.BottomSheetDialogFragment
import com.google.android.material.snackbar.Snackbar
import com.skydoves.sandwich.onError
import com.skydoves.sandwich.onSuccess
import com.team.entmaa.data.model.dto.donations.MoneyDonationsOnRequestDto
import com.team.entmaa.data.model.dto.posts.DonationRequestDto
import com.team.entmaa.data.model.dto.users.ContributorDto
import com.team.entmaa.data.sources.remote.DonationRequestsApi
import com.team.entmaa.databinding.DialogDonateMoneyBinding
import com.team.entmaa.di.FakeApi
import dagger.hilt.android.AndroidEntryPoint
import kotlinx.coroutines.launch


@AndroidEntryPoint
class DonateDialog(val item:DonationRequestDto) : BottomSheetDialogFragment()
{
    private val donationsViewModel:DonationRequestViewModel by viewModels({requireParentFragment()})

    companion object{
        const val donationAmountKey= "donationAmountKey"
    }

    lateinit var binding: DialogDonateMoneyBinding

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {

        binding = DialogDonateMoneyBinding.inflate(inflater)
        binding.donateButton.setOnClickListener {
            lifecycleScope.launch {
                binding.donationProgress.visibility = View.VISIBLE
                val moneyAmount = binding.moneyToDonate.editText?.text.toString().toInt()
                donationsViewModel.donatedMoneyToRequest(item,moneyAmount)
                    .onSuccess {
                        setFragmentResult(donationAmountKey, bundleOf(donationAmountKey to moneyAmount))
                        dismiss()
                    }.onError {
                        Snackbar.make(binding.root,"Network Error",Snackbar.LENGTH_LONG).apply {
                            setBackgroundTint(Color.RED)
                            show()
                        }
                    }

            }
        }

        return binding.root
    }

}