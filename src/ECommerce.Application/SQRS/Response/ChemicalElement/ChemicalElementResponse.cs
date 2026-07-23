namespace ECommerce.Application.SQRS.Response.ChemicalElement;

public class ChemicalElementResponse
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Symbol { get; private set; } = string.Empty;
    public decimal AtomicMass { get; private set; }
    public decimal PriceAmount { get; private set; }
    public string PriceCurrency { get; private set; } = string.Empty;
    public bool IsRadioactive { get; private set; }
    public bool IsSynthetic { get; private set; }
}