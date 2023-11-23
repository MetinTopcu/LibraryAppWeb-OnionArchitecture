using OnionArchitecture.Services.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
