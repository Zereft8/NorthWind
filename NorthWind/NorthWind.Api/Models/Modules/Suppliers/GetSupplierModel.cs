namespace NorthWind.Api.Models.Modules.Suppliers
{
    public class GetSupplierModel : SuppliersBaseModel
    {
        public int SupplierId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set;}

    }
}
