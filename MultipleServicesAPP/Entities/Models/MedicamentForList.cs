namespace MultipleServicesAPP.Entities.Models
{
    public class MedicamentForList
    {
        public int ID { get; set; }
        public string Medicamento { get; set; }
        public string Presentacion { get; set; }
        public float Precio { get; set; }
        public DateTime Fecha_Expiracion { get; set; }
        public string imgUrl { get; set; }
    }
}
