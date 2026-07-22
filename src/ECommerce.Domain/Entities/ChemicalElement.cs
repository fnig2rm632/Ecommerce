using ECommerce.Domain.Common;
using ECommerce.Domain.ValueObjects;

namespace ECommerce.Domain.Entities;

public sealed class ChemicalElement : Entity<int>
{
    public string Symbol { get; private set; }
    public string Name { get; private set; }
    public decimal AtomicMass { get; private set; }
    public Money Price { get; private set; }
    public bool IsRadioactive  { get; private set; }
    public bool IsSynthetic  { get; private set; }
    
    // ReSharper disable once CollectionNeverUpdated.Local
    private readonly List<Category> _categories = new();
    public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();

    private ChemicalElement(
        int id,
        string name, 
        string symbol, 
        decimal atomicMass, 
        Money price, 
        bool isRadioactive,
        bool isSynthetic) : base(id)
    {
        Name = name;
        Symbol = symbol;
        AtomicMass = atomicMass;
        Price = price; 
        IsRadioactive = isRadioactive;
        IsSynthetic = isSynthetic;
    }

    public static Result<ChemicalElement> Create(
        int id,
        string name, 
        string symbol, 
        decimal atomicMass, 
        Money price, 
        bool isRadioactive,
        bool isSynthetic)
    {
        var success = ValidateParameters(id, name, symbol, atomicMass);

        if (!success.IsSuccess)
            return success.Error;
        
        return new ChemicalElement(id, name, symbol, atomicMass, price, isRadioactive, isSynthetic);
    }

    private static Result ValidateParameters(
        int id,
        string name, 
        string symbol, 
        decimal atomicMass)
    {
        if (id < 1 || id > 118)
            return Error.ChemicalElement.InvalidAtomicNumber;
        
        if (string.IsNullOrWhiteSpace(name))
            return Error.ChemicalElement.EmptyName;

        if (string.IsNullOrWhiteSpace(symbol) || symbol.Length > 2)
            return Error.ChemicalElement.InvalidSymbol;

        if (atomicMass <= 0)
            return Error.ChemicalElement.NegativeAtomicMass;
        
        return Result.Success();
    }
}