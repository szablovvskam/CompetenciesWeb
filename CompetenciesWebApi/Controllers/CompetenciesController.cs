using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetenciesWebApi.Models;

namespace CompetenciesWebApi.Controllers
{
    public class CompetenciesController : ApiController
    {
        CompetencesmsEntities db = new CompetencesmsEntities();

        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(db.Competencies.ToList());
        }

        
        [HttpGet]
        public IHttpActionResult GetCompetences(int id)
        {
            return Ok(db.Competencies.Find(id));
        }

        [HttpGet]
        public IHttpActionResult GetListByTime()
        {
            return Ok(db.Competencies.OrderByDescending(c => c.Time).ToList());
        }


        [HttpPost]
        [ActionName("AddCompetence")]
        public IHttpActionResult PostAddCompetence([FromBody] Competence newCompetence)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Competencies.Add(newCompetence);
                    db.SaveChanges();
                    return Ok("Competence added.");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [ActionName("DeleteCompetence")]
        public IHttpActionResult DeleteCompetence([FromBody] int id)
        {
            try
            {
                var competence = db.Competencies.Find(id);
                db.Competencies.Remove(competence);

                db.SaveChanges();
                return Ok("Competence remove.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
