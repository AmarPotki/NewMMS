using Framework;
using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate;

public class ContractNo:ValueObject
{
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
    private ContractNo(string value)
    {
        Value = value;
    }

    public static Result<ContractNo> Create(string value)
    {
        //invarient

        return new ContractNo(value);
    }
    public string Value { get; set; }
}