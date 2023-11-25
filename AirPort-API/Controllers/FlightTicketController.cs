using AirPort_API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirPort_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightTicketController : ControllerBase
    {
        private readonly DataContext _data;

        public FlightTicketController(DataContext context)
        {
             _data = context;
        }
        // GET: api/<FlightTicketController>
        [HttpGet]
        public IEnumerable<FlightTicket> Get()
        {
            return _data.TicketsList;
        }

        // GET api/<FlightTicketController>/5
        [HttpGet("{id}")]
        public FlightTicket Get(int id)
        {
            return _data.TicketsList.Find(ft => ft.TicketId == id);
        }

        // POST api/<FlightTicketController>
        [HttpPost]
        public void Post([FromBody] FlightTicket ticket)
        {
            if (_data.flightsList.Any(f => f.FlightId == ticket.FlightId ))
            {
                _data.TicketsList.Add(new FlightTicket { TicketId = ticket.TicketId,FlightId = ticket.FlightId, PassengerId =ticket.PassengerId  });
                var updateFlight= _data.flightsList.Find(f=>f.FlightId == ticket.FlightId );
                updateFlight.PassengersId.Add(ticket.PassengerId);
            }
        }

        // PUT api/<FlightTicketController>/5
        [HttpPut("{id}")]
        public void PutFlight(int id,[FromBody] int flightId)
        {
            if(_data.flightsList.Any(f=>f.FlightId== flightId))
            {
                var ticket= _data.TicketsList.Find(t=>t.TicketId==id);
                ticket.FlightId = flightId;
            }
        }

        // DELETE api/<FlightTicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ticket= _data.TicketsList.Find(t=>t.TicketId == id);
            _data.TicketsList.Remove(ticket);
        }
    }
}
