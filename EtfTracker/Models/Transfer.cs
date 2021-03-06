using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EtfTracker.Models
{
    public class Transfer
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Amount (EUR)")]
        public EurValue Amount { get; set; }

        public int Year { get => Date.Year; }
    }
}
