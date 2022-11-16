namespace NewMMS.Contract.Domain.ContractAggregate.State;

public class DraftState : ContractState
{
    public override bool CanUpdateToWaitingForBranchAccept(Contract contract)
    {
        //check some validation

        return true;
    }
}