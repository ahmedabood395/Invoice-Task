﻿using MediatR;
using OrobaSoft.Service.Features.Dto.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrobaSoft.Service.Features.Command.Invoice
{
    public class GetInvoiceByIdCommand : IRequest<InvoiceDto>
    {
        public Guid Id { get; set; }
    }
}