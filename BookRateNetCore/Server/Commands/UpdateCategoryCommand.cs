using BookRateNetCore.Shared.Dtos;
using MediatR;

namespace BookRateNetCore.Server.Commands
{
    public class UpdateCategoryCommand : CategoryDto, IRequest
    {

    }
}
