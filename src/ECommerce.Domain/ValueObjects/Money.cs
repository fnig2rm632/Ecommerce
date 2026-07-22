using System.Globalization;
using ECommerce.Domain.Common;

namespace ECommerce.Domain.ValueObjects;

public sealed class Money : ValueObject
{
    public decimal Amount { get; private init; }
    public CurrencyCode Currency { get; private init; }
    
    private Money(){}
    
    public static Result<Money> Create(decimal amount, CurrencyCode currency)
    {
        var success = ValidateParameters(amount,  currency);

        if (!success.IsSuccess)
            return success.Error;
        
        return new Money
        {
            Amount = amount,
            Currency = currency
        };
    }

    private static Result ValidateParameters(decimal amount,  CurrencyCode currency)
    {
        if (amount < 0)
            return Error.Money.NegativeAmount(amount);
        
        if (BitConverter.GetBytes(decimal.GetBits(amount)[3])[2] > 2)
            return Error.Money.TooManyDecimalPlaces;
        
        if (!Enum.IsDefined(currency))
            return Error.Money.InvalidCurrency(currency.ToString());
        
        return Result.Success();
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    public override string ToString() => $"{Amount} {Currency}";
    
}

public enum CurrencyCode
{
    USD,
    EUR,
    JPY,
    RUB,
}