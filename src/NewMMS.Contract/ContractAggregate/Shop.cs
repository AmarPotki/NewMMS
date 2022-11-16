using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate;

public class Shop :Entity<long>
{
    public string NationalCode { get; set; }
    public string BusinessLicense { get; set; }
    public Address Address { get; set; }
    public ContactInfo ContactInfo { get; set; }
}

public class ContactInfo:ValueObject
{
    public string PhoneNumber1 { get; set; }
    public string PhoneNumber2 { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return PhoneNumber1;
        yield return PhoneNumber2;
    }
}

public class Address:ValueObject
{
    public string PostalCode { get; set; }
    public string Value { get; set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return PostalCode;
        yield return Value;
    }
}