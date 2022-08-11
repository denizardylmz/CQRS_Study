using Database_Logic.Models;

namespace BusinessLayer.CQRS.Quaries.Response;

public class GetAllProductQueryResponse
{
    public bool IsSuccess { get; set; }
    public List<Product>? Products { get; set; }
}