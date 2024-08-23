using BookRateNetCore.Server.Commands;
using BookRateNetCore.Server.Persistence;
using MediatR;

namespace BookRateNetCore.Server.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly BookDbContext _dbContext;

        public UpdateCategoryCommandHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == request.Id);
            if (category == null)
            {
                return;
            }

            category.Name = request.Name;

            await _dbContext.SaveChangesAsync();
        }
    }
}
