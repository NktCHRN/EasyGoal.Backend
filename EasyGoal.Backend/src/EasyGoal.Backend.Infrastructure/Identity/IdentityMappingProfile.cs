﻿using AutoMapper;
using EasyGoal.Backend.Application.Features.Account.Dto;

namespace EasyGoal.Backend.Infrastructure.Identity;
public sealed class IdentityMappingProfile : Profile
{
    public IdentityMappingProfile()
    {
        CreateMap<IdentityApplicationUser, AccountDto>()
            .ForMember(d => d.IsEmailConfirmed, opt => opt.MapFrom(s => s.EmailConfirmed));
    }
}
