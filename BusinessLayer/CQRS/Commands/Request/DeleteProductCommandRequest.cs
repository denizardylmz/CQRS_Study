using BusinessLayer.CQRS.Commands.Response;
using MediatR;

namespace BusinessLayer.CQRS.Commands.Request;

public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
{
    public int Id { get; set; }
}