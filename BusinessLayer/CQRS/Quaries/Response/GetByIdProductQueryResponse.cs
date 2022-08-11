using Database_Logic.Models;

namespace BusinessLayer.CQRS.Quaries.Response;

public class GetByIdProductQueryResponse
{
    public bool IsSuccess { get; set; }
    public Product? Product { get; set; }
}