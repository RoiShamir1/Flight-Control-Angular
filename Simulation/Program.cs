using RandomFriendlyNameGenerator;
using Simulation.Models;
using System.Net.Http.Json;

HttpClient client = new() { BaseAddress = new Uri("https://localhost:7097") };

var flights = await client.GetFromJsonAsync<IEnumerable<FlightDto>>("api/Flights");
var loggers = await client.GetFromJsonAsync<IEnumerable<LoggerDto>>("api/Loggers");

System.Timers.Timer timer = new System.Timers.Timer(10000);
timer.Elapsed += (s, e) => CreateFlight();
timer.Start();

Console.ReadLine();

async void CreateFlight()
{
    var flight = new FlightDto { IsDepature = null};
    var response = await client.PostAsJsonAsync("api/Flights", flight);
    if (response.IsSuccessStatusCode)
    {
        Console.WriteLine($"The number of the flight is {flight.Code}");
        Console.WriteLine();
    }
}
