using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeassurementsController : ControllerBase
    {
       
        // GET: api/Meassurements
        [HttpGet]
        [Route("Getall")] // husk at benytte den i url'en.
        public List<Meassurement> GetAll()
        {
             return MeassurementFunctions.GetAll();
        }

        // GET: api/Meassurements/5
        [HttpGet("{id}", Name = "Get")]
        public Meassurement Get(int id)
        {
            return MeassurementFunctions.Get(id);
        }

        // POST: api/Meassurements
        [HttpPost]
        [Route("Add")]
        public Meassurement Post([FromBody] Meassurement m)
        {
            return MeassurementFunctions.Add(m);
        }

        // PUT: api/Meassurements/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Route("Delete")]
        public Meassurement Delete(int id)
        {
            return MeassurementFunctions.Delete(id);
        }
    }
}
