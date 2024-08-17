using BookRateNetCore.Server.Persistence;
using BookRateNetCore.Shared.Models;
using BookRateNetCore.Shared.Services;
using Microsoft.JSInterop;
using System.Text.Json;


namespace BookRateNetCore.Client.Services
{
    public class BookService : IBookService
    {

        private readonly BookDbContext _context;


        public BookService(BookDbContext context)
        {
            _context = context;
        }



        public void Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public async Task Delete(Guid bookId)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == bookId);
            if (book is null)
                return;

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public async Task DeleteAll()
        {
            _context.Books.RemoveRange(_context.Books);
            _context.SaveChanges();
            //await _context.SaveChangesAsync();
        }

        public List<Book> GetAll()
        {
            var books = _context.Books.ToList();
            return books;
        }



    }
}
