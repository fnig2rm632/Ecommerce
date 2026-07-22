namespace ECommerce.Application.SQRS.Response.ChemicalElements;

public record ChemicalElementResponse(
    int Id,
    string Name, 
    string Symbol, 
    decimal AtomicMass, 
    decimal PriceAmount,
    string PriceCurrency,
    bool IsRadioactive,
    bool IsSynthetic);