using TesteAnkix.Webapi.Application.ViewModels.Country;
using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Message.Abstraction;

namespace TesteAnkix.Webapi.Application.Queries.Country
{
    public interface ICountryQuery
    {
        Task<IApplicationResult<IEnumerable<CountryResultViewModel>>> GetAllAsync();
    }
}
