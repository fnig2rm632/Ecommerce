namespace ECommerce.Application.SQRS.Requests;

public class ElementByCategoriesRequest
{
    public List<int> CategoryIds { get; set; } = new();
}