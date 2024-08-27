using MediatR;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Service.Features.Command.Invoice;

namespace OrobaSoft.Service.Features.Handler.Invoice
{
    public class DeleteInvoiceHandler : IRequestHandler<DeleteInvoiceCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                    var invoice = _unitOfWork.Invoice.GetById(request.Id);
                _unitOfWork.Invoice.Delete(invoice);
                    _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                
            }
            return request.Id;


        }
    }
}
