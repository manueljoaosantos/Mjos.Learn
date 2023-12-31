﻿using Mjos.Learn.ProductCatalog.Data;

namespace Mjos.Learn.ProductCatalog
{
    public static class Extensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, string connStringKey, IConfiguration config)
        {
            services.AddPostgresDbContext<MainDbContext>(
                    config.GetConnectionString(connStringKey),
                    options =>
                    {
                        options.UseModel(MainDbContextModel.Instance);
                    },
                    svc => svc.AddRepository(typeof(Repository<>)))
                .AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddCdCConsumers(this IServiceCollection services, IConfiguration config)
        {
            /*services.AddKafkaConsumer(o =>
            {
                o.Topic = "supplier_cdc_events";
                o.GroupId = "supplier_cdc_events_product_catalog_group";
                o.AutoOffsetReset = AutoOffsetReset.Earliest;
                o.AllowAutoCreateTopics = true;
                o.EventResolver = async (eventFullName, bytes, schemaRegistryClient) =>
                {
                    ISpecificRecord? result = null;
                    if (eventFullName == typeof(SupplierCreated).FullName)
                    {
                        result = await bytes.DeserializeAsync<SupplierCreated>(schemaRegistryClient);
                    }
                    else if (eventFullName == typeof(SupplierUpdated).FullName)
                    {
                        result = await bytes.DeserializeAsync<SupplierUpdated>(schemaRegistryClient);
                    }
                    else if (eventFullName == typeof(SupplierDeleted).FullName)
                    {
                        result = await bytes.DeserializeAsync<SupplierDeleted>(schemaRegistryClient);
                    }

                    return result;
                };
            });*/

            services.AddKafkaConsumer(o =>
            {
                o.Topic = "product_cdc_events";
                o.GroupId = "product_cdc_events_product_catalog_group";
                o.AutoOffsetReset = AutoOffsetReset.Earliest;
                o.AllowAutoCreateTopics = true;
                o.EventResolver = async (eventFullName, bytes, schemaRegistryClient) =>
                {
                    ISpecificRecord? result = null;
                    if (eventFullName == typeof(ProductCreated).FullName)
                    {
                        result = await bytes.DeserializeAsync<ProductCreated>(schemaRegistryClient);
                    }
                    else if (eventFullName == typeof(ProductDeleted).FullName)
                    {
                        result = await bytes.DeserializeAsync<ProductDeleted>(schemaRegistryClient);
                    }
                    else if (eventFullName == typeof(ProductUpdated).FullName)
                    {
                        result = await bytes.DeserializeAsync<ProductUpdated>(schemaRegistryClient);
                    }

                    return result;
                };
            }, config);

            return services;
        }
    }

}
