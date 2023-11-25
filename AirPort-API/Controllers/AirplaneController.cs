using AirPort_API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirPort_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneController : ControllerBase
    {
        private readonly DataContext _data;
        public AirplaneController(DataContext context)
        {
            _data=context;
        }


        // GET: api/<AirplaneController>
        [HttpGet]
        public IEnumerable<AirPlane> Get()
        {
            return _data.airplaneList;
        }

        // GET api/<AirplaneController>/5
        [HttpGet("{id}")]
        public AirPlane Get(int id)
        {
            return _data.airplaneList.Find(a => a.AirplaneId== id);
        }

        // POST api/<AirplaneController>
        [HttpPost]
        public void Post( [FromBody] AirPlane airPlane)
        {
            _data.airplaneList.Add(new AirPlane
            {
                AirplaneId = airPlane.AirplaneId,
                Company = airPlane.Company,
                NumSeats = airPlane.NumSeats,
                IsProper = airPlane.IsProper
            }) ;
        }

        // PUT api/<AirplaneController>/5
        [HttpPut("{id}")]
        public void PutPropriety(int id,[FromBody] bool isProper)
        {
            var plane = _data.airplaneList.Find(a => a.AirplaneId == id);
            plane.IsProper= isProper;
        }

        // DELETE api/<AirplaneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var plane = _data.airplaneList.Find(a => a.AirplaneId == id);
            _data.airplaneList.Remove(plane); 
        }
    }
}
