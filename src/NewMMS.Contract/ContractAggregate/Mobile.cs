using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate;

public class Mobile : ValueObject
{
    public string Value { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}