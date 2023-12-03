using OnionArchitecture.Services.Core.Application.CommonDto;
using OnionArchitecture.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Application.Dtos
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }

        //public ICollection<BookDto> Books { get; set; }
    }
}
