using BusinessLayer.Context;
using BusinessLayer.CQRS.Quaries.Request;
using BusinessLayer.CQRS.Quaries.Response;
using Database_Logic.Models;
using MediatR;

namespace BusinessLayer.CQRS.Handlers.QueryHandlers;

public class GetAllProductQueryHandlers : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
{
    private readonly CQRSDbContext _context;

    public GetAllProductQueryHandlers(CQRSDbContext context)
    {
        _context = context;
    }
    

    public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        var products = _context.Products.ToList();
        
        if (products.Count == 0)
            return new GetAllProductQueryResponse() { IsSuccess = false , Products = null};

        return new GetAllProductQueryResponse() { IsSuccess = true, Products = products };
    }
}