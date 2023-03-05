using TesteAnkix.Webapi.Application.ViewModels.Country;
using System.Net;
using Framework.Message.Abstraction;
using Framework.Message.Concrete;
using TesteAnkix.Webapi.Application.ViewModels.Rates;
using System.Collections.Generic;

namespace TesteAnkix.Webapi.Application.Queries.Rates
{
    public class RatesQuery : IRatesQuery
    {
        List<RatesResultViewModel> listRates = new List<RatesResultViewModel>();
        List<VatResultViewModel> listVat = new List<VatResultViewModel>();

        public RatesQuery()
        {
            listRates.Add(new RatesResultViewModel { RatesId = 1, Value = 6.0, CountryId = 1 });
            listRates.Add(new RatesResultViewModel { RatesId = 2, Value = 13.0, CountryId = 1 });
            listRates.Add(new RatesResultViewModel { RatesId = 3, Value = 23.0, CountryId = 1 });
            listRates.Add(new RatesResultViewModel { RatesId = 4, Value = 5.0, CountryId = 2 });
            listRates.Add(new RatesResultViewModel { RatesId = 5, Value = 20.0, CountryId = 2 });
            listRates.Add(new RatesResultViewModel { RatesId = 6, Value = 21.0, CountryId = 3 });
            listRates.Add(new RatesResultViewModel { RatesId = 7, Value = 10.0, CountryId = 3 });
            listRates.Add(new RatesResultViewModel { RatesId = 8, Value = 5.5, CountryId = 4 });
            listRates.Add(new RatesResultViewModel { RatesId = 9, Value = 20.0, CountryId = 4 });
            listRates.Add(new RatesResultViewModel { RatesId = 10, Value = 10.0, CountryId = 4 });

            listVat.Add(new VatResultViewModel { VatId = 1, Name = "Price without VAT" });
            listVat.Add(new VatResultViewModel { VatId = 2, Name = "Value-Added Tax" });
            listVat.Add(new VatResultViewModel { VatId = 3, Name = "Price incl. VAT" });

        }

        public async Task<IApplicationResult<IEnumerable<RatesResultViewModel>>> GetAllAsync(int countryId)
        {
            IApplicationResult<IEnumerable<RatesResultViewModel>> result = new ApplicationResult<IEnumerable<RatesResultViewModel>>();

            result.Result = listRates.Where(x => x.CountryId == countryId);

            if (result.Result.Count() == 0)
            {
                result.HttpStatusCode = HttpStatusCode.UnprocessableEntity;
                result.Validations.Add("Invalid reates. request can only return logged user record.");

                return result;
            }

            return result;
        }
        public async Task<IApplicationResult<IEnumerable<VatResultViewModel>>> GetVatAsync()
        {
            IApplicationResult<IEnumerable<VatResultViewModel>> result = new ApplicationResult<IEnumerable<VatResultViewModel>>();

            result.Result = listVat;

            if (result.Result.Count() == 0)
            {
                result.HttpStatusCode = HttpStatusCode.UnprocessableEntity;
                result.Validations.Add("Invalid vat. request can only return logged user record.");

                return result;
            }

            return result;
        }

        public async Task<IApplicationResult<CalculedResultViewModel>> GetCalculedAsync(CalculedRequestViewMode request)
        {
            IApplicationResult<CalculedResultViewModel> result = new ApplicationResult<CalculedResultViewModel>();

            if(request.Value == 0 || request.VatId == 0 || request.RatesId == 0)
            {
                result.HttpStatusCode = HttpStatusCode.UnprocessableEntity;
                result.Validations.Add("Invalid calculed. request can only return logged user record.");

                return result;
            }

            CalculedResultViewModel rs = new CalculedResultViewModel();
            double valuePercent = 0.0;

            switch (request.VatId)
            {
                case 1:
                    valuePercent = listRates.Where(x => x.RatesId == request.RatesId).FirstOrDefault().Value * request.Value;
                    rs.Net = request.Value;
                    rs.Gross = request.Value + valuePercent;
                    rs.Vat = valuePercent;
                    break; 
                case 2:
                    valuePercent = request.Value;
                    rs.Gross = (request.Value * 100) / listRates.Where(x => x.RatesId == request.RatesId).FirstOrDefault().Value;
                    rs.Vat = request.Value;
                    rs.Net = rs.Gross - rs.Vat;
                    break;
                case 3:
                    valuePercent = listRates.Where(x => x.RatesId == request.RatesId).FirstOrDefault().Value * request.Value;
                    rs.Net = request.Value - valuePercent;
                    rs.Gross = request.Value;
                    rs.Vat = valuePercent;
                    break;
                default:
                    result.HttpStatusCode = HttpStatusCode.UnprocessableEntity;
                    result.Validations.Add("Invalid calculed. request can only return logged user record.");

                    return result;
            }

            result.Result = rs;

            return result;
        }
    }
}
