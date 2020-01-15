using AutoMapper;
using GDS.Bible.Core.Models;
using GDS.Bible.SeedData.MyBibles;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Bible.SeedData
{
    public class SeedDictionary
    {
        Repository _repo;
        private readonly IMapper _mapper;
        public SeedDictionary()
        {
            _repo = new Repository();
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MyBibles.Models.Dictionary, BibleDictionary>();
                cfg.CreateMap<MyBibles.Models.CognateStrongNumber, CognateStrongNumber>();
                cfg.CreateMap<MyBibles.Models.MorphologyIndication, MorphologyIndication>();

            }));
        }

         
    }
}
