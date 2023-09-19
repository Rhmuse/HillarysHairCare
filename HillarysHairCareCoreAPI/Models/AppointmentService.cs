using System.ComponentModel.DataAnnotations;

namespace HillarysHairCareCoreAPI.Models
{
    public class AppointmentService
    {
        public int Id { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        [Required]
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public bool IsCanceled { get; set; }
    }
}
