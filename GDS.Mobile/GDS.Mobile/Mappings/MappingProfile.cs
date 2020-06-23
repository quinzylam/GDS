using AutoMapper;
using GDS.Core.Models;
using GDS.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Mobile.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BibleModel, Bible>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}