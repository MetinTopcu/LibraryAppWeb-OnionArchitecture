using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Application.Dtos
{
    public class BookCreateDto
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
