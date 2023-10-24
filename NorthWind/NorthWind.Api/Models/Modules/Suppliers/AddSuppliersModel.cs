namespace NorthWind.Api.Models.Modules.Suppliers
{
    public class AddSuppliersModel : SuppliersBaseModel
    {
        public int IdUsuarioCreacion { get; set; }
        public DateTime FechaRegistro { get; set; }

    }
}
