using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleServicesAPP.Entities.Models
{
    public class MedicamentForPicker
    {
        public int ID { get; set; }
        public string Medicamento { get; set; }
        public string Presentacion { get; set; }
        public string Precio { get; set; }
    }
}
