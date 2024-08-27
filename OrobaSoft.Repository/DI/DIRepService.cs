using Microsoft.Extensions.DependencyInjection;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Repository.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Text;



namespace OrobaSoft.Repository.DI
{
  public static  class DIRepService
    {
        private static IServiceProvider serviceProvider=null;

        public static IServiceProvider ServiceProvider { get; set; }

        public static void RegisterRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped<IInvoiceRepository,InvoiceRepository>();
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
