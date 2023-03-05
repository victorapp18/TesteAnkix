using Framework.Message.Abstraction;
using TesteAnkix.Webapi.Application.ViewModels.Rates;

namespace TesteAnkix.Webapi.Application.Queries.Rates
{
    public interface IRatesQuery
    {
        Task<IApplicationResult<IEnumerable<RatesResultViewModel>>> GetAllAsync(int countryId);
        Task<IApplicationResult<IEnumerable<VatResultViewModel>>> GetVatAsync();
        Task<IApplicationResult<CalculedResultViewModel>> GetCalculedAsync(CalculedRequestViewMode request);
    }
}
