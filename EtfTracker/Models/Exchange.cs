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
        [Column(TypeName = "decimal(18, 2)")]
        public decimal EurAmount { get; set; }

        [Display(Name = "EUR Rate (HUF)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal EurRateInHuf { get; set; }

        public decimal CostInHuf { get => EurAmount * EurRateInHuf; }
    }
}