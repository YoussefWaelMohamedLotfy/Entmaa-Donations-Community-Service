package com.team.entmaa.data.model.dto.users

import java.time.LocalDate

enum class Gender{
    Male, Female
}

class ContributorDto : UserDto()
{
    var birthDate:LocalDate = LocalDate.now()
    var gender: Gender = Gender.Male
    var followingCount:Int = 0
    var badgesCount:Int = 0
}

