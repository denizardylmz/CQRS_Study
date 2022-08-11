using BusinessLayer.CQRS.Quaries.Response;
using MediatR;

namespace BusinessLayer.CQRS.Quaries.Request;

public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
{
    public int Id { get; set; }
}