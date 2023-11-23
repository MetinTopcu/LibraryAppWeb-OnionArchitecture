using OnionArchitecture.Services.Core.Application.CommonDto;
using OnionArchitecture.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Application.Dtos
{
    public class BookDto : BaseDto
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }
    }
}
