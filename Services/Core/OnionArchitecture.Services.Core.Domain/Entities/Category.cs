using OnionArchitecture.Services.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Core.Domain.Entities
{
    public class Category : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
