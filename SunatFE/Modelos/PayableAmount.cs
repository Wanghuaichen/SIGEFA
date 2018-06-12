using System;

namespace SunatFE
{
    [Serializable]
    public class PayableAmount
    {
        public string currencyID { get; set; }
        public decimal value { get; set; }
    }
}