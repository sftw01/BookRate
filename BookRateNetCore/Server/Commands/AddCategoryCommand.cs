using MediatR;

namespace BookRateNetCore.Server.Commands
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}