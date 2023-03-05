using System;
using System.Runtime.Serialization;
namespace TesteAnkix.Webapi.Application.ViewModels.Rates
{
    [DataContract(Name = "Rates", Namespace = "http://TesteAnkix.com/reuslt/type/Country")]
    public class CalculedResultViewModel
    {
        [DataMember(Name = "Net")]
        public double Net { get; set; }

        [DataMember(Name = "Gross")]
        public double Gross { get; set; }

        [DataMember(Name = "Vat")]
        public double Vat { get; set; }
    }
}
