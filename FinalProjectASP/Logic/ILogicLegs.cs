using FinalProjectASP.Models;

namespace FinalProjectASP.Logic
{
    public interface ILogicLegs
    {
        Task<IEnumerable<Flight>> GetAllFlights();
        Task<Flight> GetFlightById(int id);
        Task AddFlight(Flight flight);
        Task DeleteFlight(int id);
        Task <IEnumerable<Logger>> GetAllLogger();
        Task<Logger> GetLoggerById(int id);
        Task DeleteLogger(int id);
        Task NextTerminal(Flight flight, Leg leg);
    }
}