using MediatR;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Service.Features.Command.Invoice;
using OrobaSoft.Service.Features.Dto.Invoice;

namespace OrobaSoft.Service.Features.Handler.Invoice
{
    public class GetInvoiceByIdHandler : IRequestHandler<GetInvoiceByIdCommand, InvoiceDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetInvoiceByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InvoiceDto> Handle(GetInvoiceByIdCommand request, CancellationToken cancellationToken)
        {
                    var invoices = _unitOfWork.Invoice.GetAll().Select(n=> new InvoiceDto
                    {
                        Id = n.Id,
                        InvoiceName =n.InvoiceName,
                        InvoiceNumber =n.InvoiceNumber,
                    }).FirstOrDefault();
            return await Task.FromResult(invoices);
        }
    }
}
