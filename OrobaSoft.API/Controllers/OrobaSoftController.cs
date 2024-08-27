
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrobaSoft.API.Dto.Invoice;
using OrobaSoft.Service.Features.Command.Invoice;
using OrobaSoft.Service.Features.Dto.Invoice;

namespace OrobaSoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrobaSoftController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ResponseDto _responseDto;

        public OrobaSoftController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDto();
        }
        [HttpPost]
        public async Task<Guid> AddInvoice(AddInvoiceCommand request)
        {
            var result = await _mediator.Send(request);
            
            return await Task.FromResult(result);
        }
        [HttpPut("UpdateInvoice")]
        public async Task<Guid> UpdateInvoice(UpdateInvoiceCommand request)
        {
            return await _mediator.Send(request);
        }
        [HttpDelete]
        [Route("DeleteInvoice/{id}")]
        public async Task<Guid> DeleteInvoice(Guid id)
        {
            return await _mediator.Send(new DeleteInvoiceCommand { Id = id });
        }
        [HttpGet]
        [Route("GetInvoiceById/{id}")]
        public async Task<ResponseDto> GetInvoiceById(Guid id)
        {
            _responseDto.Result = await _mediator.Send(new GetInvoiceByIdCommand { Id = id });
            return _responseDto;
        }
        [HttpGet]
        [Route("GetAllInvoice")]
        public async Task<List<InvoiceDto>> GetAllInvoice()
        {
            return  await _mediator.Send(new GetAllInvoiceCommand());
        }
    }
}
