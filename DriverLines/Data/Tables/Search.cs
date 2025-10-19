using System.ComponentModel.DataAnnotations;

namespace DriverLines.Data.Tables
{
    public class Search
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "المنطقة")]
        [Required]
        public string Area { get; set; }

        [Display(Name = "رقم السيارة")]
        public string VehicleNumber { get; set; }

        [Display(Name = "اسم السائق")]
        public string DriverName { get; set; }

        [Display(Name = "رمز الخط")]
        public string LineCode { get; set; }


    }
}
