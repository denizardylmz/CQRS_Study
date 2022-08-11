using BusinessLayer.Context;
using BusinessLayer.CQRS.Commands.Request;
using BusinessLayer.CQRS.Commands.Response;
using MediatR;

namespace BusinessLayer.CQRS.Handlers.CommandHandlers;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
{
    private readonly CQRSDbContext _context;


    public DeleteProductCommandHandler(CQRSDbContext context)
    {
        _context = context;
    }
    

    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == request.Id);

        if (product is null)
            return new DeleteProductCommandResponse() { IsSuccess = false };

        _context.Products.Remove(product);
        _context.SaveChanges();

        return new DeleteProductCommandResponse() { IsSuccess = true };
    }
}