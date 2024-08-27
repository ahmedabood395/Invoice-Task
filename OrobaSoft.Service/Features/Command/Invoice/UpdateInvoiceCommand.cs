using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Service.Features.Command.Invoice
{
    public class UpdateInvoiceCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceName { get; set; }
    }
}
