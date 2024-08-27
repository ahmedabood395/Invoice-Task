using OrobaSoft.Repository.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrobaSoft.Repository.Interfaces   
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoice { get; }
        void Commit();
    }
}
