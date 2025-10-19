using System.ComponentModel.DataAnnotations;

namespace DriverLines.Data.Tables
{
    public class Line
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Area { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        public int Capacity { get; set; }
        public int RemainingSeats { get; set; }
        public string DriverName { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public string Year { get; set; }
        public string GenderType { get; set; }
        public bool Cooling { get; set; }
    
}
}
