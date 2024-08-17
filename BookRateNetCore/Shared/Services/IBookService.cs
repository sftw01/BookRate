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
        void Create(Book book);
        Task Delete(Guid bookId);
        List<Book> GetAll();
        Task DeleteAll();
    }
}
