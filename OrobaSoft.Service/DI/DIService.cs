using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;



namespace OrobaSoft.Service.DI
{
  public static  class DIService
    {
        private static IServiceProvider serviceProvider=null;

        public static IServiceProvider ServiceProvider { get; set; }

        public static void RegisterService(this IServiceCollection collection)
        {
        }

        public static void DisposeServices()
        {
            if (serviceProvider == null)
            {
                return;
            }
            if (serviceProvider is IDisposable)
            {
                ((IDisposable)serviceProvider).Dispose();
            }
        }
    }
}
