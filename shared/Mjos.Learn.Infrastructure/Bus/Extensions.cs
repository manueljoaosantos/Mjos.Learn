using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mjos.Learn.Infrastructure.Bus.Dapr;
using Mjos.Learn.Infrastructure.Bus.Dapr.Internal;
using Mjos.Learn.Infrastructure.Bus.Kafka;

namespace Mjos.Learn.Infrastructure.Bus
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services,
            IConfiguration config,
            string messageBrokerType = "dapr")
        {
            switch (messageBrokerType)
            {
                case "dapr":
                    services.Configure<DaprEventBusOptions>(config.GetSection(DaprEventBusOptions.Name));
                    services.AddScoped<IEventBus, DaprEventBus>();
                    break;
            }

            return services;
        }

        public static IServiceCollection AddKafkaConsumer(this IServiceCollection services,
            Action<KafkaConsumerConfig> configAction)
        {
            services.AddHostedService<BackGroundKafkaConsumer>();

            services.AddOptions<KafkaConsumerConfig>()
                .BindConfiguration(KafkaConsumerConfig.Name)
                .Configure(configAction);

            return services;
        }
    }
}
