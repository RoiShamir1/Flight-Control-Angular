namespace Simulation.Models
{
    public class LoggerDto
    {
        public virtual LegDto? Leg { get; set; }
        public virtual FlightDto? Flight { get; set; }
        public DateTime GetIn { get; set; }
        public DateTime GetOut { get; set; }
    }
}
