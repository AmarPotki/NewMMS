using System.Text.RegularExpressions;
using Framework;
using Framework.Domain;

namespace NewMMS.Contract.Domain.ContractAggregate
{
    public class AccountInfo : ValueObject
    {
        public string Iban { get; }
        public Bank Bank { get; }
        private AccountInfo(string input, Bank bank)
        {
            Iban = input;
            Bank = bank;
        }
        public static Result<AccountInfo> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<AccountInfo>("");
            if (Regex.IsMatch(input, "^(?=.{13}$)[0-9]*$"))
            {
                try
                {
                    input = IbanConvertor.ConvertAccountToIban(long.Parse(input), AccountType.Sepordeh);
                }
                catch (Exception e)
                {
                    return Result.Failure<AccountInfo>("account is not correct");
                }

            }
            //^(?=.{24}$)[0-9]*$
            if (!Regex.IsMatch(input, "^(?=.{24}$)[0-9]*$"))
                return Result.Failure<AccountInfo>("iban format is not correct");
            var bank = Bank.From(int.Parse(input.Substring(3, 2)));
            return new AccountInfo(input, bank);

        }
        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Iban;
            yield return Bank;
        }
    }


    public class Bank : Enumeration
    {
        public Bank(int id, string name)
            : base(id, name)
        {

        }

        public static Bank Ayandeh = new(62, "Ayandeh");
        public static Bank Meli = new(17, "Meli");
        public static Bank Parsian = new(54, "Parsian");
        public static Bank Mellat = new(12, "Mellat");
        public static Bank Saman = new(56, "Saman");

        public static IEnumerable<Bank> List() =>
            new[] { Ayandeh, Meli, Parsian, Mellat, Saman };
        public static Bank From(int id)
        {
            var bank = List().SingleOrDefault(s => s.Id == id);

            if (bank is null)
            {
                throw new KeyNotFoundException($"Possible values for Bank: {string.Join(",", List().Select(s => s.Name))}");
            }

            return bank;
        }

    }
}
