using Microsoft.Extensions.DependencyInjection;
using OrobaSoft.Repository.Context;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Repository.Interfaces.Invoice;
using System;
using System.Data.SqlClient;

namespace OrobaSoft.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        IServiceProvider _serviceProvider;
        public InvoiceContext Context { get; }

        

        public UnitOfWork(InvoiceContext context, IServiceProvider serviceProvider)
        {
            Context = context;
            _serviceProvider = serviceProvider;
        }
        IInvoiceRepository invoice = null;

        public IInvoiceRepository Invoice
        {
            get
            {
                return invoice ?? _serviceProvider.GetService<IInvoiceRepository>();
            }
        }
        public void Commit()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (SqlException ex)
            {
            }

        }
    }

}

