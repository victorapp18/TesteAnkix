using System;
using System.Runtime.Serialization;
namespace TesteAnkix.Webapi.Application.ViewModels.Rates
{
    [DataContract(Name = "Rates", Namespace = "http://TesteAnkix.com/reuslt/type/Country")]
    public class RatesResultViewModel
    {
        [DataMember(Name = "RatesId")]
        public int RatesId { get; set; }

        [DataMember(Name = "Value")]
        public double Value { get; set; }

        [DataMember(Name = "CountryId")]
        public int CountryId { get; set; }
    }
}
