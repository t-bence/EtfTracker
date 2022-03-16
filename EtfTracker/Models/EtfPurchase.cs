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
        public EurValue Price { get; set; }

        public int Year { get => Date.Year; }

        public static readonly EurValue Fee = new EurValue(6.5m);

        public EurValue TotalCostEur { get => (EurValue)(Price + Fee); }

    }

}
