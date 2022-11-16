using FluentAssertions;
using NewMMS.Contract.Domain.ContractAggregate;

namespace NewMMS.Contract.UnitTests;

public class CustomerTests
{
    public static IEnumerable<object[]> ValidShebas =>
        new List<object[]>
        {
            new object[] { "830620000000201441170004", Bank.Ayandeh },
            new object[] { "280560085680000518058001",Bank.Saman},
        };

    [Theory]
    [MemberData(nameof( ValidShebas))]
    public void Operator_is_able_to_Create_Customer(string sheba,Bank bank)
    {
        //280560085680000518058001
        var account = AccountInfo.Create(sheba);
        var nationalId = NationalId.Create("3934489907");
        var customer = Merchant.Create("Amar","Potki", nationalId.Value, account.Value);
        customer.IsSuccess.Should().BeTrue();
        customer.Value.AccountInfo.Should().NotBeNull();
        account.Value.Bank.Should().Be(bank);
    }

    [Fact]
    public void Operator_is_Not_able_to_Create_Customer_By_wrong_NationalCode()
    {
        var account = AccountInfo.Create("830620000000201441170004");
        var nationalId = NationalId.Create("3934489908");
        nationalId.IsSuccess.Should().BeFalse();
      
    }
    [Fact]
    public void Operator_is_able_to_Create_Customer_By_Ayandeh_AccountNumber()
    {
        var account = AccountInfo.Create("0202631979006");
        var nationalId = NationalId.Create("3934489907");
        var customer = Merchant.Create("Amar", "Potki", nationalId.Value, account.Value);
        customer.IsSuccess.Should().BeTrue();
        customer.Value.AccountInfo.Should().NotBeNull();
        account.Value.Bank.Should().Be(Bank.Ayandeh);

    }
}