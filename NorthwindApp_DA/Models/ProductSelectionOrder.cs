using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindApp_DA.Models
{
    internal class ProductSelectionOrder
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryID { get; set; }
        public string SupplierID { get; set; }
    }   
}
