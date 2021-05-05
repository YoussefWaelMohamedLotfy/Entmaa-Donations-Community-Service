package com.team.entmaa.data.repositories

sealed class Result<out T : Any> {
    data class Success<out T : Any>(val data: T) : Result<T>()
    data class Error(val message: String) : Result<Nothing>()
    object InProgress : Result<Nothing>()
}

fun<T:Any> Result<T>.onLoading(block:() -> Unit) : Result<T>
{
    if(this is Result.InProgress)
    {
        block()
    }

    return this
}

fun<T:Any> Result<T>.onSuccess(block:(T) -> Unit) : Result<T>
{
    if(this is Result.Success)
    {
        block(this.data)
    }

    return this
}

fun<T:Any> Result<T>.onError(block:(String) -> Unit) : Result<T>
{
    if(this is Result.Error)
    {
        block(this.message)
    }

    return this
}