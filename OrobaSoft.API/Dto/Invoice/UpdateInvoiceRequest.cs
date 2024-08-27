namespace OrobaSoft.API.Dto.Invoice
{
    public class UpdateInvoiceRequest
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
        public string InvoiceName { get; set; }
    }
}
