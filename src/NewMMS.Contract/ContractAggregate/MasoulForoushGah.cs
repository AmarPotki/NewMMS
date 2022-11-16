using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate;

public class MasoulForoushGah : ValueObject
{
    public Mobile Mobile { get; set; }
    public string FullName { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Mobile;
        yield return FullName;
    }
}