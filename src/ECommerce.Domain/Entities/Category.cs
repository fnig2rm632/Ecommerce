using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public sealed class Category : Entity<int>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private Category(int id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    private Category(string name, string description) : base(0)
    {
        Name = name;
        Description = description;
    }

    public static Result<Category> Create(string name, string description)
    {
        var success = ValidateParameters(name, description);
        
        if (!success.IsSuccess)
            return success.Error;
        
        return new Category(name, description);
    }
    
    public static Result<Category> Create(int id, string name, string description)
    {
        var success = ValidateParameters(name, description);
        
        if (!success.IsSuccess)
            return success.Error;
        
        return new Category(id, name, description);
    }

    private static Result ValidateParameters(string name, string description)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Error.Category.EmptyName;

        if (name.Length > 50)
            return Error.Category.NameTooLong(50);
        
        if (description.Length > 255)
            return Error.Category.DescriptionTooLong(255);
        
        return Result.Success();
    }
}
