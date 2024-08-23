using BookRateNetCore.Server.Commands;
using BookRateNetCore.Server.Persistence;
using MediatR;
using BookRateNetCore.Shared.Models;

namespace BookRateNetCore.Server.Handlers
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand>
    {
        private readonly BookDbContext _dbContext;

        public AddCategoryCommandHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            _dbContext.Categories.Add( new Category(request.Name));
            _dbContext.SaveChanges();
        }
    }
}
