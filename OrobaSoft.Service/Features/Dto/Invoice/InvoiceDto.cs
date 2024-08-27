using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Service.Features.Dto.Invoice
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceName { get; set; }
    }
}
