using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mjos.Learn.Core.Domain;
using Mjos.Learn.Infrastructure.TxOutbox.Dapr;
using Mjos.Learn.Infrastructure.TxOutbox.Dapr.Internal;
using Mjos.Learn.Infrastructure.TxOutbox.InMemory;

namespace Mjos.Learn.Infrastructure.TxOutbox
{
    public class TxOutboxConstants
    {
        public const string InMemory = "inmem";
        public const string Dapr = "dapr";
    }

    public static class Extensions
    {
        public static IServiceCollection AddTransactionalOutbox(this IServiceCollection services, IConfiguration config,
            string provider = TxOutboxConstants.InMemory)
        {
            switch (provider)
            {
                case TxOutboxConstants.InMemory:
                    {
                        services.AddSingleton<IEventStorage, EventStorage>();
                        services.AddScoped<INotificationHandler<EventWrapper>, LocalDispatchedHandler>();
                        services.AddScoped<ITxOutboxProcessor, TxOutboxProcessor>();
                        break;
                    }
                case TxOutboxConstants.Dapr:
                    {
                        services.Configure<DaprTxOutboxOptions>(config.GetSection(DaprTxOutboxOptions.Name));
                        services.AddScoped<INotificationHandler<EventWrapper>, DaprLocalDispatchedHandler>();
                        services.AddScoped<ITxOutboxProcessor, DaprTxOutboxProcessor>();
                        break;
                    }
            }

            return services;
        }
    }
}
