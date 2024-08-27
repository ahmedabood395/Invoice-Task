using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Model.Entity
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceName { get; set; }
    }
}
