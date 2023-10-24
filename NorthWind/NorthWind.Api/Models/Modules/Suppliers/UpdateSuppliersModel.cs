namespace NorthWind.Api.Models.Modules.Suppliers
{
    public class UpdateSuppliersModel : SuppliersBaseModel
    {
        
        public int SupplierID { get; set; }
        public int IdUsuarioMod { get; set; }
        public DateTime FechaMod { get; set; }
        public string? City { get; set; }
    }
}
