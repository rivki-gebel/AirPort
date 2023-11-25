using AirPort_API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirPort_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassangerController : ControllerBase
    {
        private readonly DataContext _data;

        public PassangerController(DataContext context)
        {
            _data = context;
        }
        // GET: api/<PassangerController>
        [HttpGet]
        public IEnumerable<Passanger> Get()
        {
            return _data.passangersList;
        }

        // GET api/<PassangerController>/5
        [HttpGet("{id}")]
        public Passanger Get(int id)
        {
            return _data.passangersList.Find(p => p.IdNum == id);
        }

        // POST api/<PassangerController>
        [HttpPost]
        public void Post( [FromBody] Passanger passanger)
        {
            _data.passangersList.Add(new Passanger { IdNum = passanger.IdNum, Name = passanger.Name , Adress= passanger.Adress});
        }

        // PUT api/<PassangerController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] Passanger passanger)
        {
            var pass= _data.passangersList.Find(p=>p.IdNum == id);
            pass.Adress= passanger.Adress;
            pass.Name= passanger.Name;
        }

        // DELETE api/<PassangerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pass=_data.passangersList.Find(p=>p.IdNum == id);
            _data.passangersList.Remove(pass);


        }
    }
}
