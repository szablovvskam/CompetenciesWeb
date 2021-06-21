using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetenciesWebApi.Models;

namespace CompetenciesWebApi.Controllers
{
    public class CoffeeController : ApiController
    {
        CompetencesmsEntitiesC db = new CompetencesmsEntitiesC();

        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(db.Coffees.ToList());
        }

        [HttpGet]
        public IHttpActionResult GetCoffee(int id)
        {
            return Ok(db.Coffees.Find(id));
        }


        [HttpDelete]
        [ActionName("DeleteCoffee")]
        public IHttpActionResult DeleteCoffee([FromBody] int id)
        {
            try
            {
                var coffee = db.Coffees.Find(id);
                db.Coffees.Remove(coffee);

                db.SaveChanges();
                return Ok("Coffee remove.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
