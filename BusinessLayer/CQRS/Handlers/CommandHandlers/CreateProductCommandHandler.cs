using BusinessLayer.Context;
using BusinessLayer.CQRS.Commands.Request;
using BusinessLayer.CQRS.Commands.Response;
using Database_Logic.Models;
using MediatR;

namespace BusinessLayer.CQRS.Handlers.CommandHandlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private CQRSDbContext _context;

    public CreateProductCommandHandler(CQRSDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = _context.Products.Add(new Product()
        {
            Name = request.Name,
            Stock = request.Stock
        });

        _context.SaveChanges();

        var resultProductId = _context.Products.Where(p => p.Name == request.Name ).Select(p => p.Id).FirstOrDefault(); 
        
        return new CreateProductCommandResponse() { IsSuccess = true, Id = resultProductId};
    }
}