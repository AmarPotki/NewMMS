using Framework;
using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate;

public class Merchant : Entity<long>
{
    private Merchant(string firstName, string lastName, NationalId nationalId, AccountInfo accountInfo)
    {
        FirstName = firstName;
        LastName = lastName;
        AccountInfo = accountInfo;
        NationalId = nationalId;
    }
    public static Result<Merchant> Create(string firstName, string lastName, NationalId nationalId, AccountInfo accountInfo)
    {
        if (accountInfo is null) throw new ArgumentNullException(nameof(accountInfo));
        ArgumentNullException.ThrowIfNull(nationalId);

        return new Merchant(firstName, lastName, nationalId, accountInfo);
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public AccountInfo AccountInfo { get; private set; }
    public NationalId NationalId { get; private set; }

    public MerchantType MerchantType { get; set; }

}
// enum or Inheritance
public enum MerchantType
{
    Actual,
    Legal,
    Shared
}