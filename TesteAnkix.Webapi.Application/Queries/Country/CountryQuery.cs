using TesteAnkix.Webapi.Application.ViewModels.Country;
using System.Net;
using Framework.Message.Abstraction;
using Framework.Message.Concrete;
using System.Collections.Generic;

namespace TesteAnkix.Webapi.Application.Queries.Country
{
    public class CountryQuery : ICountryQuery
    {
        List<CountryResultViewModel> listCountry = new List<CountryResultViewModel>();

        public CountryQuery()
        {
            listCountry.Add(new CountryResultViewModel { CountryId = 1, Name = "Portugal" });
            listCountry.Add(new CountryResultViewModel { CountryId = 2, Name = "United Kingdom" });
            listCountry.Add(new CountryResultViewModel { CountryId = 3, Name = "Spain" });
            listCountry.Add(new CountryResultViewModel { CountryId = 4, Name = "France" });

        }

        public async Task<IApplicationResult<IEnumerable<CountryResultViewModel>>> GetAllAsync()
        {
            IApplicationResult<IEnumerable<CountryResultViewModel>> result = new ApplicationResult<IEnumerable<CountryResultViewModel>>();

            result.Result = listCountry;

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
