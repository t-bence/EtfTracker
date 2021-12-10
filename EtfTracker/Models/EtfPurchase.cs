using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtfTracker.Models
{
    public class EtfPurchase
    {

        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Price (EUR)")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal EurPrice { get; set; }

        public int Year { get => Date.Year; }

        public static readonly decimal Fee = 6.5m;

    }

}
