namespace NewMMS.Contract.Domain.TerminalAggregate.State;

public abstract class TerminalState
{
    public virtual bool CanUpdateToDefinedInSwitch(Terminal terminal) => false;
    public virtual bool CanUpdateToAssigned(Terminal terminal) => false;
    public virtual bool CanUpdateToNasb(Terminal terminal) => false;
    public virtual bool CanUpdateToJamaavary(Terminal terminal) => false;
}

public class JamaavaryState : TerminalState
{

}