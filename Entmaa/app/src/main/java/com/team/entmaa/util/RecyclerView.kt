package com.team.entmaa.util

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.databinding.DataBindingUtil
import androidx.databinding.ViewDataBinding
import androidx.recyclerview.widget.DiffUtil
import androidx.recyclerview.widget.ListAdapter
import androidx.recyclerview.widget.RecyclerView

open class BaseListAdapter
    <Item : Any,Binding : ViewDataBinding>
    (private val layoutId:Int,
     val bindItem: Binding.(item:Item,position:Int) -> Unit = { _,_ -> /* No Op */} ) :
    ListAdapter<Item, BaseListAdapter.BaseViewHolder<Binding>>(BaseItemCallback<Item>())
{

    class BaseViewHolder<Binding : ViewDataBinding>
     private constructor(val binding : Binding) : RecyclerView.ViewHolder(binding.root)
    {

        companion object {

            fun <Binding : ViewDataBinding>from (parent: ViewGroup, layoutId: Int) : BaseViewHolder<Binding>
            {
                val inflater = LayoutInflater.from(parent.context)
                val binding = DataBindingUtil.inflate<Binding>(inflater,layoutId,parent,false)
                return BaseViewHolder(binding)
            }

        }

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int)
    : BaseViewHolder<Binding> {
        return BaseViewHolder.from(parent,layoutId)
    }

    override fun onBindViewHolder(holder: BaseViewHolder<Binding>, position: Int) {
        holder.binding.bind(getItem(position),position)
    }


    open fun Binding.bind(item: Item, position:Int) = this.bindItem(item,position)


    class BaseItemCallback<T : Any> : DiffUtil.ItemCallback<T>() {
        override fun areItemsTheSame(oldItem: T, newItem: T) = oldItem == newItem

        override fun areContentsTheSame(oldItem: T, newItem: T) = oldItem == newItem
    }


}