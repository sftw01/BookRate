using BookRateNetCore.Shared.Dtos;
using BookRateNetCore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRateNetCore.Shared.Services
{
    public interface IBookService
    {
        Task<List<CategoryDto>> GetCategories();
        Task DeleteCategory(Guid id);
        Task UpdateCategory(CategoryDto category);
        Task AddCategory(CategoryDto category);

    }
}
