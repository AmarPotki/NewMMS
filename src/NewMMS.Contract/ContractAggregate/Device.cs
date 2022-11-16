namespace NewMMS.Contract.Domain.ContractAggregate;

public class Device
{
    public int Id { get; private set; }
    public DeviceType DeviceType { get; set; }
}
public enum DeviceType
{
    Pos,
    Modem,
    Sandogh,

}