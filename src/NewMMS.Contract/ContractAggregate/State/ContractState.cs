namespace NewMMS.Contract.Domain.ContractAggregate.State;

public abstract class ContractState
{
    public virtual bool CanUpdateToWaitingForBranchAccept(Contract contract) => false;
    public virtual bool CanUpdateToWaitingForDefiningInSwitch(Contract contract) => false;
    public virtual bool CanUpdateToNeedToCompleteContractProperties(Contract contract) => false;
    public virtual bool CanUpdateToDefinedInSwitch(Contract contract) => false;
    public virtual bool CanUpdateToAssigned(Contract contract) => false;
    public virtual bool CanUpdateToNasb(Contract contract) => false;
    public virtual bool CanUpdateToJamaavary(Contract contract) => false;
}