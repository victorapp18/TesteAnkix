using MediatR;
using Microsoft.AspNetCore.Mvc;
using Framework.Message.Abstraction;
using TesteAnkix.Webapi.Application.Queries.Rates;
using TesteAnkix.Webapi.Application.ViewModels.Rates;

namespace TesteAnkix.WebApi.Assets.Controllers
{
    [ApiController]
    [Route("api/rates")]
    public class RatesController : Controller
    {
        private IMediator Mediator { get; }
        private IRatesQuery RatesQuery { get; }

        public RatesController(IMediator mediator, IRatesQuery ratesQuery) 
        {
            Mediator = mediator;
            RatesQuery = ratesQuery;
        }

        [HttpGet, Produces("application/json", Type = typeof(IApplicationResult<IEnumerable<RatesResultViewModel>>))]
        public async Task<IActionResult> GetMyAsync(int countryId) => await RatesQuery.GetAllAsync(countryId);

        [HttpGet("vat"), Produces("application/json", Type = typeof(IApplicationResult<IEnumerable<VatResultViewModel>>))]
        public async Task<IActionResult> GetVatAsync() => await RatesQuery.GetVatAsync();

        [HttpPost("calculed"), Produces("application/json", Type = typeof(IApplicationResult<IEnumerable<CalculedResultViewModel>>))]
        public async Task<IActionResult> GetCalculedAsync([FromForm] CalculedRequestViewMode request) => await RatesQuery.GetCalculedAsync(request);
    }
}
