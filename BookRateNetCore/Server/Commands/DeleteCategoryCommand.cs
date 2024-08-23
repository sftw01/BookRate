using MediatR;

namespace BookRateNetCore.Server.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
