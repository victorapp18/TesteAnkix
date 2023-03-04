using System;
using System.Runtime.Serialization;
namespace TesteAnkix.Webapi.Application.ViewModels.Country
{
    [DataContract(Name = "Country", Namespace = "http://TesteAnkix.com/reuslt/type/Country")]
    public class CountryResultViewModel
    {
        [DataMember(Name = "CountryId")]
        public int CountryId { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
