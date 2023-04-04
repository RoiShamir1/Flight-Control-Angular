using System.ComponentModel.DataAnnotations;

namespace FinalProjectASP.Models
{
    public class Flight
    {
        public int Id { get; set; }
        [Required]
        public Guid Code { get; set; }
        public bool IsDeparture { get; set; }
    }
}
