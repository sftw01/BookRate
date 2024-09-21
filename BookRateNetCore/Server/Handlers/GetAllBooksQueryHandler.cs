using MediatR;
using BookRateNetCore.Shared.Commands;
using BookRateNetCore.Server.Persistence;
using Microsoft.EntityFrameworkCore;
using BookRateNetCore.Shared.Models;
using BookRateNetCore.Shared.Queries;
using BookRateNetCore.Shared.Dtos;

namespace BookRateNetCore.Server.Handlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBookQuery, List<Book>>
    {

        private readonly BookDbContext _dbContext;

        public GetAllBooksQueryHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Book>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
        {
            //if as argument is passed id, return book with that id
            if (request.Id is not null)
            {
                var book = _dbContext.Books
                    .Include(b => b.Images)
                    .FirstOrDefault(x => x.Id == request.Id);
                return Task.FromResult(new List<Book> { book });
            }


            //if as argument is passsed pageNumber and pAGEsIZE, RETURN MATCHING BOOKS
            if (request.PageNumber is not null && request.PageSize is not null)
            {
                var book = _dbContext.Books
                    .Include(b => b.Images)
                    .Skip((request.PageNumber.Value - 1) * request.PageSize.Value)
                    .Take(request.PageSize.Value)
                    .ToList();
                return Task.FromResult(book);

            }

            //if qyery is empty, return all books
            var books = _dbContext.Books
                .Include(b => b.Images)
                .ToList();
            return Task.FromResult(books);
        }


    }
}
