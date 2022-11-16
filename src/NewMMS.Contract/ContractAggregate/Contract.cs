using Framework;
using Framework.Domain;
using NewMMS.Contract.Domain.ContractAggregate.State;

namespace NewMMS.Contract.Domain.ContractAggregate
{
    public class Contract : AggregateRoot<long>
    {
        public static Result<Contract> Create()
        {
            return new Contract();
        }
        private Contract()
        {
            CurrentState = new DraftState();
        }

        public Terminal2 Terminal { get; set; }
        public Brokers Brokers { get; set; }
        public IReadOnlyCollection<Device> Devices { get; set; }

        public ContractNo ContractNo { get; set; }
        public MasoulForoushGah MasoulForoushGah { get; set; }
        public Shop Shop { get; private set; }
        public int ProjectId { get; private set; }
        public int GroupId { get; private set; }
        public int CityId { get; private set; }
        public Merchant Merchant { get; set; }
        public int ProvinceId { get; private set; }
        public AccountInfo AccountInfo { get; set; }
        public ContractState CurrentState { get; set; }

        public Result CanUpdateToWaitingForBranchAccept()
        {
            return CurrentState.CanUpdateToWaitingForBranchAccept(this) ? Result.Failure("") : Result.Success();
        }

        public void SendToBranch()
        {
            if (!CurrentState.CanUpdateToWaitingForBranchAccept(this))
                throw new Exception();

            CurrentState = new WaitingForBranchAcceptState();
        }
    }
}