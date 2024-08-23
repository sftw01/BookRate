using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public Category()
        {
            Id = Guid.NewGuid();
        }

        public Category(string Name)
        {
            this.Name = Name;
            Id = Guid.NewGuid();
        }
    }
}
