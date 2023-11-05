using NorthWind.Api.Models.NewFolder;

namespace NorthWind.Api.Models.Modules.Order
{
    public abstract class OrderBaseModel : ModelBase

    {


        
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }


    }

}
