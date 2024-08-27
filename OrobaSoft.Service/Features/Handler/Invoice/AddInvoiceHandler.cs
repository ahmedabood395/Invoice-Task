using MediatR;
using OrobaSoft.Model.Entity;
using OrobaSoft.Repository.Interfaces;
using OrobaSoft.Service.Features.Command.Invoice;

namespace OrobaSoft.Service.Features.Handler.Invoice
{
    public class AddInvoiceHandler : IRequestHandler<AddInvoiceCommand, Guid>
    {

        private readonly IUnitOfWork _unitOfWork;

        public AddInvoiceHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var invoice = new Model.Entity.Invoice();

                invoice.InvoiceNumber = request.InvoiceNumber;
                invoice.InvoiceName = request.InvoiceName;
                _unitOfWork.Invoice.Insert(invoice);
                    _unitOfWork.Commit();
                return invoice.Id;

            }
            catch (Exception ex)
            {
                return new Guid();
            }
        }
    }
}
