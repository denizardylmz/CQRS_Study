using BusinessLayer.Context;
using BusinessLayer.CQRS.Quaries.Request;
using BusinessLayer.CQRS.Quaries.Response;
using MediatR;

namespace BusinessLayer.CQRS.Handlers.QueryHandlers;

public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
{
    private readonly CQRSDbContext _context;

    public GetByIdProductQueryHandler(CQRSDbContext context)
    {
        _context = context;
    }

    public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
    {
        var product = _context.Products.Find(request.Id);

        if (product is null)
            return new GetByIdProductQueryResponse() { IsSuccess = false, Product = null };

        return new GetByIdProductQueryResponse() { IsSuccess = true, Product = product };
    }
}