using BusinessLayer.CQRS.Commands.Response;
using MediatR;

namespace BusinessLayer.CQRS.Commands.Request;

public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public int Stock { get; set; }
}