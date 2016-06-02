using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTap.Model;
using _m = BeerTap.Repository.Model;

namespace BeerTap.WebApi
{
    public class AutoMapperConfig
    {

        public static void RegisterMapping()
        {
            AutoMapper.Mapper.CreateMap<Office, _m.Office>()
                .ReverseMap();
            AutoMapper.Mapper.CreateMap<Keg, _m.Keg>()
                .ReverseMap();
        }
    }
}