using MediatR;
using BookRateNetCore.Shared.Commands;
using BookRateNetCore.Server.Persistence;
using Microsoft.EntityFrameworkCore;
using BookRateNetCore.Shared.Models;

namespace BookRateNetCore.Server.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {

        private readonly BookDbContext _dbContext;

        public CreateBookCommandHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            _dbContext.Books.Add(request);
            _dbContext.SaveChanges();

        }
    }
}
