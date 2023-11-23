using AutoMapper;
using OnionArchitecture.Services.Core.Application.Dtos;
using OnionArchitecture.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
