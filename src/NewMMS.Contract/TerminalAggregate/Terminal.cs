using Framework.Domain;

namespace NewMMS.Contract.Domain.TerminalAggregate;

public class Terminal : AggregateRoot<long>
{
    public long ContractId { get; set; }
    public string MerchantNo { get; set; }
    public string TerminalNo { get; set; }
    public DateTime TarikhTarifDarSwitch { get; set; }
}

