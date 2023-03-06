using System;
using Framework.Message.Concrete;

namespace TesteAnkix.Webapi.Application.ViewModels.Rates
{
    public class CalculedRequestViewMode
    {
        public int VatId { get; set; }
        public int RateId { get; set; }    
        public double Value { get; set; }
    }
}
