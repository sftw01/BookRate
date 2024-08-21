using MediatR;

namespace BookRateNetCore.Server.Commands
{
    public class DeleteBookCommand: IRequest
    {
        public Guid Id { get; set; }

    public DeleteBookCommand(Guid id)
    {
        Id = id;
    }
}
}
