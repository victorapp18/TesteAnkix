using System;
using System.Runtime.Serialization;
namespace TesteAnkix.Webapi.Application.ViewModels.Rates
{
    [DataContract(Name = "Rates", Namespace = "http://TesteAnkix.com/reuslt/type/Country")]
    public class VatResultViewModel
    {
        [DataMember(Name = "VatId")]
        public int VatId { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }
    }
}
