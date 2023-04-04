namespace Simulation.Models
{
    public class FlightDto
    {
        public string? Code { get; set; }
        public FlightDto() => Code = Guid.NewGuid().ToString();
        public bool? IsDepature { get; set; }
    }
}