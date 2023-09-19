using System.ComponentModel.DataAnnotations;

namespace HillarysHairCareCoreAPI.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        public int StylistId { get; set; }
        public Stylist? Stylist { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public List<AppointmentService>? AppointmentServices { get; set; }
        public decimal? Total
        {
            get
            {
                decimal? total = 0M;
                AppointmentServices?.ForEach(a =>
                {
                    total += a?.Service?.Cost;
                });
                return total;
            }
        }
        [Required]
        public DateTime Date { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsCompleted { get; set; }
    }
}
