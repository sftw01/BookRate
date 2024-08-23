using BookRateNetCore.Server.Commands;
using BookRateNetCore.Server.Persistence;
using MediatR;

namespace BookRateNetCore.Server.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly BookDbContext _dbContext;

        public DeleteCategoryCommandHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == request.Id);

            if(category is null)
            {
                // optionally to handle exception when category is not found
                return;
            }

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }
    }
}
