namespace Mjos.Learn.Infrastructure.TxOutbox
{
    public interface ITxOutboxProcessor
    {
        Task HandleAsync(Type integrationAssemblyType, CancellationToken cancellationToken = new());
    }
}
