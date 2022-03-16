using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtfTracker.Models
{
    public class Exchange
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Amount (EUR)")]
        public EurValue Amount { get; set; }

        [Display(Name = "EUR Rate (HUF)")]
        public ExchangeRate OneEurInHuf { get; set; }

        public HufValue CostInHuf { get => (HufValue)(Amount * OneEurInHuf); }
    }
}