namespace IBKS.Contracts.Base;

public abstract class ContractBase<T>
{
    public virtual T Id { get; set; }
}