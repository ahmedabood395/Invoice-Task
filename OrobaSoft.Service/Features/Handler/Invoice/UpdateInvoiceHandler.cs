using MediatR;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Service.Features.Command.Invoice;

namespace OrobaSoft.Service.Features.Handler.Invoice
{
    public class UpdateInvoiceHandler : IRequestHandler<UpdateInvoiceCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                    var invoice = _unitOfWork.Invoice.GetById(request.Id);

                invoice.InvoiceNumber = request.InvoiceNumber;
                invoice.InvoiceName = request.InvoiceName;
                _unitOfWork.Invoice.Update(invoice);
                    _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                
            }
            return request.Id;


        }
    }
}
