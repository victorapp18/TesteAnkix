using TesteAnkix.Webapi.Application.ViewModels.Country;
using System.Net;
using Framework.Message.Abstraction;
using Framework.Message.Concrete;
using TesteAnkix.Webapi.Application.Queries.Channel;

namespace TesteAnkix.Webapi.Application.Queries.Country
{
    public class CountryQuery : ICountryQuery
    {
        public CountryQuery()
        {
        }

        public async Task<IApplicationResult<IEnumerable<CountryResultViewModel>>> GetAllAsync()
        {
            IApplicationResult<IEnumerable<CountryResultViewModel>> result = new ApplicationResult<IEnumerable<CountryResultViewModel>>();

            List<CountryResultViewModel> list = new List<CountryResultViewModel>();
            list.Add(new CountryResultViewModel { CountryId = 1, Name = "Portugal" });
            list.Add(new CountryResultViewModel { CountryId = 2, Name = "United Kingdom" });
            list.Add(new CountryResultViewModel { CountryId = 2, Name = "Spain" });
            list.Add(new CountryResultViewModel { CountryId = 2, Name = "France" });

            result.Result = list;

            if (result.Result.Count() == 0)
            {
                result.HttpStatusCode = HttpStatusCode.UnprocessableEntity;
                result.Validations.Add("Invalid country. request can only return logged user record.");

                return result;
            }

            return result;
        }
    }
}
