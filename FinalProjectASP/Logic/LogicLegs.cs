using FinalProjectASP.Data;
using FinalProjectASP.Models;
using Microsoft.EntityFrameworkCore;
using RandomFriendlyNameGenerator;
using System.Diagnostics;

namespace FinalProjectASP.Logic
{
    public class LogicLegs : ILogicLegs
    {
        private readonly DataContext _context;

        public LogicLegs(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetAllFlights() => await _context.Flights.ToListAsync();

        public async Task<Flight> GetFlightById(int id)
        {
            try
            {
                var movie = await _context.Flights.SingleOrDefaultAsync(x => x.Id == id);
                return movie!;
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public async Task AddFlight(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();

            var startLeg = _context.Legs.First(l => l.Number == 1);
            startLeg.FlightId = flight.Id;
            await NextTerminal(flight, startLeg);
        }

        public async Task NextTerminal(Flight flight, Leg leg)
        {
            var log = new Logger { FlightId = flight.Id, Leg = leg, GetIn = DateTime.Now };
            await _context.Loggers.AddAsync(log);
            Thread.Sleep(leg.WaitTime * 1000);
            var nextLeg = _context.Legs.FirstOrDefault(l => leg.NextLegs.HasFlag(l.CurrentLeg));
            if (leg.CurrentLeg == LegNumber.Fou && flight.IsDeparture)
            {
                log.GetOut = DateTime.Now;
                leg.FlightId = null;
                await _context.SaveChangesAsync();
                return;
            }
            while (nextLeg?.FlightId != null)
            {
                Thread.Sleep(2000);
            }
            nextLeg!.FlightId = flight.Id;
            leg.FlightId = null;
            log.GetOut = DateTime.Now;
            flight.IsDeparture = leg.IsChangeStatus;
            await _context.SaveChangesAsync();
            await NextTerminal(flight, nextLeg);
        }

        public async Task DeleteFlight(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (flight != null)
            {
                _context.Flights.Remove(flight);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Logger>> GetAllLogger() => await _context.Loggers.ToListAsync();

        public async Task<Logger> GetLoggerById(int id)
        {
            try
            {
                var logger = await _context.Loggers.SingleOrDefaultAsync(x => x.Id == id);
                return logger!;
            }
            catch (Exception)
            {
                throw new NullReferenceException();
            }
        }

        public async Task DeleteLogger(int id)
        {
            var logger = await _context.Loggers.FindAsync(id);
            if (logger != null)
            {
                _context.Loggers.Remove(logger);
                await _context.SaveChangesAsync();
            }
        }
    }
}
