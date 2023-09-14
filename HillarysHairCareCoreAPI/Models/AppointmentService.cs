using System.ComponentModel.DataAnnotations;

namespace HillarysHairCareCoreAPI.Models
{
    public class AppointmentService
    {
        public int Id { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}
