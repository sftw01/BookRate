using BookRateNetCore.Server.Commands;
using BookRateNetCore.Server.Persistence;
using MediatR;

namespace BookRateNetCore.Server.Handlers
{
    public class DeleteAllBooksCommandHandler : IRequestHandler<DeleteAllBooksCommand>
    {
        
        private readonly BookDbContext _dbContext;

        public DeleteAllBooksCommandHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Handle(DeleteAllBooksCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Books.RemoveRange(_dbContext.Books);
            _dbContext.SaveChanges();
            await _dbContext.SaveChangesAsync();
        }


    }

}
