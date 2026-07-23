namespace ECommerce.Application.SQRS.Response.Category;

public class CategoryResponse{

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
}