package com.team.entmaa.data.repositories

sealed class Result<out T : Any> {
    data class Success<out T : Any>(val data: T) : Result<T>()
    data class Error(val message: String) : Result<Nothing>()
    object InProgress : Result<Nothing>()
}