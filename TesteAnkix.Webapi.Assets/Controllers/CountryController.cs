using MediatR;
using Microsoft.AspNetCore.Mvc;
using Framework.Message.Abstraction;
using TesteAnkix.Webapi.Application.ViewModels.Country;
using TesteAnkix.Webapi.Application.Queries.Country;

namespace TesteAnkix.WebApi.Assets.Controllers
{
    [ApiController]
    [Route("api/country")]
    public class CountryController : Controller
    {
        private IMediator Mediator { get; }
        private ICountryQuery CountryQuery { get; }

        public CountryController(IMediator mediator, ICountryQuery countryQuery) 
        {
            Mediator = mediator;
            CountryQuery = countryQuery;
        }

        [HttpGet, Produces("application/json", Type = typeof(IApplicationResult<IEnumerable<CountryResultViewModel>>))]
        public async Task<IActionResult> GetMyAsync() => await CountryQuery.GetAllAsync();
    }
}
