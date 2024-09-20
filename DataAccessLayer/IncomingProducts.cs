using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class IncomingProducts
    {
        public int ID { get; set; }
        public string Unit { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public int MaterialDescriptionID { get; set; }
        public string MaterialDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int DepartmentID { get; set; }
        public string Department { get; set; }
        public int SupplierID { get; set; }
        public string Supplier { get; set; }
        public int ExchangeRateID { get; set; }
        public string ExchangeRate { get; set; }
        public decimal TurkishLiraEquivalent { get; set; }
    }
}
