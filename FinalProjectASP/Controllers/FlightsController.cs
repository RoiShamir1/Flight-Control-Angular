using FinalProjectASP.Logic;
using FinalProjectASP.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace FinalProjectASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly ILogicLegs _logicLegs;

        public FlightsController(ILogicLegs logicLegs)
        {
            _logicLegs = logicLegs;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            if (_logicLegs.GetAllFlights == null)
            {
                return NotFound();
            }
            var flights = await _logicLegs.GetAllFlights();

            return Ok(flights);
        }

        //GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            var flight = await _logicLegs.GetFlightById(id);

            if (flight == null)
            {
                //return BadRequest();
                return NotFound(id);
            }

            return Ok(flight);
        }
        [HttpPost]
        public async Task<IActionResult> /*<ActionResult<Flight>>*/ PostFlight(Flight flight)
        {
            if (_logicLegs.GetAllFlights == null)
            {
                return Problem("Flights not found");
            }

            await _logicLegs.AddFlight(flight);
            return NoContent();
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFlight(int id)
        {
            if (_logicLegs.GetAllFlights == null)
            {
                return NotFound();
            }
            var flight = await _logicLegs.GetFlightById(id);

            if (flight == null)
            {
                return NotFound();
            }

            await _logicLegs.DeleteFlight(id);
            return NoContent();
        }

        [HttpGet]
        [Route("/api/loggers")]
        public async Task<ActionResult<IEnumerable<Logger>>> GetLoggers()
        {
            if (_logicLegs.GetAllLogger == null)
            {
                return NotFound();
            }
            var loggers = await _logicLegs.GetAllLogger();

            return Ok(loggers);
        }

        [HttpGet]
        [Route("/api/loggers/{id}")]
        [EnableCors("*")]
        public async Task<ActionResult<Logger>> Getlogger(int id)
        {
            var logger = await _logicLegs.GetLoggerById(id);

            if (logger == null)
            {
                //return BadRequest();
                return NotFound(id);
            }
            return Ok(logger);
        }

        [HttpDelete]
        [Route("/api/loggers/{id}")]
        public async Task<IActionResult> RemoveLogger(int id)
        {
            if (_logicLegs.GetAllLogger == null)
            {
                return NotFound();
            }
            var logger = await _logicLegs.GetLoggerById(id);

            if (logger == null)
            {
                return NotFound();
            }

            await _logicLegs.DeleteLogger(id);
            return NoContent();
        }
    }
}
