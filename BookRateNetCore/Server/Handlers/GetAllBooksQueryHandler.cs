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
            var books = _dbContext.Books.ToList();
            return Task.FromResult(books);
        }

  
    }
}
