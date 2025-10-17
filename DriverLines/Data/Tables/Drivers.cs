using System.ComponentModel.DataAnnotations;

namespace DriverLines.Data.Tables
{
    public class Drivers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "اسم السائق")]
        public string DriverName { get; set; }

        [Required]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Display(Name = "نوع السيارة")]
        public string VehicleType { get; set; }

        [Display(Name = "رقم السيارة")]
        public string VehicleNumber { get; set; }

        [Display(Name = "عدد الركاب الكلي")]
        public int TotalSeats { get; set; }

        [Display(Name = "عدد الركاب المتبقي")]
        public int RemainingSeats { get; set; }

        [Display(Name = "المناطق")]
        public string Areas { get; set; }

        [Display(Name = "ملاحظات / تقييم")]
        public string Notes { get; set; }

        [Display(Name = "تبريد؟")]
        public bool HasAC { get; set; }

        [Display(Name = "سنة الصنع")]
        public int ManufactureYear { get; set; }

        [Display(Name = "نوع الخط")]
        public string LineType { get; set; } // شباب - بنات - مختلط

        [Display(Name = "رمز الخط")]
        public string LineCode { get; set; }

        [Display(Name = "الحالة")]
        public bool IsActive { get; set; } = true;
    }
}
