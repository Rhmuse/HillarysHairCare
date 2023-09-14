using System.ComponentModel.DataAnnotations;

namespace HillarysHairCareCoreAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }
    }
}
