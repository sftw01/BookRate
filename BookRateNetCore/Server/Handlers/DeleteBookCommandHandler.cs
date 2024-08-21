using MediatR;
using BookRateNetCore.Shared.Commands;
using BookRateNetCore.Server.Commands;

using BookRateNetCore.Server.Persistence;
using Microsoft.EntityFrameworkCore;
using BookRateNetCore.Shared.Models;
using System.Net;

namespace BookRateNetCore.Server.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly BookDbContext _dbContext;

        public DeleteBookCommandHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            var book = _dbContext.Books.FirstOrDefault(b => b.Id == request.Id );
            if (book is null)
            {
                // optionally to handle exception when book is not found
                return;
            }

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
