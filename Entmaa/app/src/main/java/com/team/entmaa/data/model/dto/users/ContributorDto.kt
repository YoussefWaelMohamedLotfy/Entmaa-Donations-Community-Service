package com.team.entmaa.data.model.dto.users

import java.time.LocalDate

enum class Gender{
    Male, Female
}

class ContributorDto : UserDto()
{
    var birthDate:LocalDate? = null
    var gender: Gender? = null
}

