using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Service.Features.Command.Invoice
{
    public class AddInvoiceCommand : IRequest<Guid>
    {
        public int InvoiceNumber { get; set; }
        public string InvoiceName { get; set; }
    }
}
