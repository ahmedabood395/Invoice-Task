using MediatR;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Service.Features.Command.Invoice;
using OrobaSoft.Service.Features.Dto.Invoice;

namespace OrobaSoft.Service.Features.Handler.Invoice
{
    public class GetAllInvoiceHandler : IRequestHandler<GetAllInvoiceCommand, List<InvoiceDto>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<InvoiceDto>> Handle(GetAllInvoiceCommand request, CancellationToken cancellationToken)
        {
                    var invoices = _unitOfWork.Invoice.GetAll().Select(n=> new InvoiceDto
                    {
                        Id = n.Id,
                        InvoiceName =n.InvoiceName,
                        InvoiceNumber =n.InvoiceNumber,
                    }).ToList();
            return await Task.FromResult(invoices);
        }
    }
}
