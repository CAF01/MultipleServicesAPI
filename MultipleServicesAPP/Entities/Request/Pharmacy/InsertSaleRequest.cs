using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleServicesAPP.Entities.Request.Pharmacy
{
    public class InsertSaleRequest
    {
        //public DateTime registeredDate { get; set; }
        public int quantity { get; set; }
        public int idItem { get; set; }
    }
}
