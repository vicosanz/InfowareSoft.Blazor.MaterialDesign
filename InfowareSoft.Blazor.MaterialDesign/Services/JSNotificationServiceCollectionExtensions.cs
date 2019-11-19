using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfowareSoft.Blazor.MaterialDesign
{
    public static class JSNotificationServiceCollectionExtensions
    {
        public static IServiceCollection AddJSNotificationService(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.TryAdd(ServiceDescriptor.Transient<IJSNotificationService, JSNotificationService>());
            return serviceCollection;
        }
    }
}
