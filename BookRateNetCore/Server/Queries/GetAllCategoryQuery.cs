using BookRateNetCore.Shared.Dtos;
using MediatR;

namespace BookRateNetCore.Server.Queries
{
    public class GetAllCategoryQuery : IRequest<List<CategoryDto>>
    {
    }
}
