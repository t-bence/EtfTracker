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
        [DataType(DataType.Currency)]
        public decimal EurPrice { get; set; }

        public EtfType EtfType { get; set; }

        public int Year { get => Date.Year; }

    }

    public class EtfType
    {
        public int ID { get; set; }
        public string Name { get; private set; }
        public string ApiIdentifier { get; private set; }

        protected EtfType(string name, string apiIdentifier)
        {
            Name = name;
            ApiIdentifier = apiIdentifier;
        }

        public static EtfType SP500 = new("S&P 500", "XETRA:xxx");
        public static EtfType WorldSmallCap = new("World Small Cap", "XETRA:xxx");
    }
}
