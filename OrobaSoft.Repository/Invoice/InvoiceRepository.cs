using OrobaSoft.Repository.Context;
using OrobaSoft.Repository.Interfaces.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Repository.Interfaces
{
    public class InvoiceRepository : GenericRepository<OrobaSoft.Model.Entity.Invoice>,IInvoiceRepository
    {
        public InvoiceRepository(InvoiceContext context) : base(context)
        {
            
        }

    }
}
