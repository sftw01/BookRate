using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared.Services
{
    public interface IBookSeeder
    {
        Task SeedBook();
        Task SeedCategory();
    }
}
