namespace FinalProjectASP.Models
{
    public class Logger
    {
        public int Id { get; set; }
        public virtual Leg? Leg { get; set; }
        public int? FlightId { get; set; }
        public DateTime GetIn { get; set; }
        public DateTime GetOut { get; set; }
    }
}
