package com.team.entmaa.util

import com.google.android.material.chip.Chip
import com.google.android.material.chip.ChipGroup

fun ChipGroup.onAllChecked(operation: (chip: Chip) -> Unit){
    checkedChipIds.forEach { id ->
        val chip = this.findViewById<Chip>(id)
        operation(chip)
    }
}