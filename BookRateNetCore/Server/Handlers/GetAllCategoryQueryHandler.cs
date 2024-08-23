using MediatR;
using BookRateNetCore.Shared.Dtos;
using BookRateNetCore.Shared.Queries;
using BookRateNetCore.Server.Queries;
using BookRateNetCore.Server.Persistence;

namespace BookRateNetCore.Server.Handlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly BookDbContext _dbContext;

        public GetAllCategoryQueryHandler(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = _dbContext.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
            return categories.ToList();
        }
    }
}
