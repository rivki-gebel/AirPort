using AirPort_API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirPort_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly DataContext _data;
        public FlightController(DataContext context)
        {
            _data = context;
        }

        // GET: api/<FlightController>
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return _data.flightsList;
        }

        // GET api/<FlightController>/5
        [HttpGet("{id}")]
        public Flight Get(int id)
        {
            return _data.flightsList.Find(f => f.FlightId == id);
        }

        // POST api/<FlightController>
        [HttpPost]
        public void Post([FromBody]Flight flight)
        {
            _data.flightsList.Add(new Flight
            {
                FlightId = flight.FlightId,
                Destination = flight.Destination,
                SourceLand = flight.SourceLand,
                AirplaneId = flight.AirplaneId,
                Cost = flight.Cost,
                TakeingOffTime = flight.TakeingOffTime
            });
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public void PutCost(int id,[FromBody] double cost)
        {
            var flight= _data.flightsList.Find(f => f.FlightId == id);
            flight.Cost= cost;  
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var flight = _data.flightsList.Find(f => f.FlightId == id);
            _data.flightsList.Remove(flight);
        }
    }
}
