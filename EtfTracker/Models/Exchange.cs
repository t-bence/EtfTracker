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
        public decimal EurAmount { get; set; }

        [Display(Name = "EUR Rate (HUF)")]
        public decimal EurRateInHuf { get; set; }

        public decimal CostInHuf { get => EurAmount * EurRateInHuf; }
    }
}