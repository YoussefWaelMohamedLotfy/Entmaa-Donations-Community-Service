package com.team.entmaa.ui.tags

import com.google.android.material.chip.Chip
import com.team.entmaa.R
import com.team.entmaa.data.model.dto.tags.TagDto
import com.team.entmaa.databinding.ItemTagBinding
import com.team.entmaa.util.BaseListAdapter

class TagsAdapter(val onTagClick:(TagDto,Boolean,Set<TagDto>) -> Unit) : BaseListAdapter<TagDto,ItemTagBinding>(R.layout.item_tag) {

    private val mCheckedFilters = mutableSetOf<TagDto>()
    val checkedFilters: Set<TagDto> = mCheckedFilters

    override fun ItemTagBinding.bind(item: TagDto, position: Int) {
        tag.text = item.name

        tag.isChecked = mCheckedFilters.contains(item)

        tag.setOnClickListener {
            it as Chip

            if(tag.isChecked)
            {
                mCheckedFilters.add(item)
            }
            else
            {
                mCheckedFilters.remove(item)
            }

            onTagClick(item,tag.isChecked,checkedFilters)
        }
    }

}