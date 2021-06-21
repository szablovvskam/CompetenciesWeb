using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetenciesWebApi.Models;

namespace CompetenciesWebApi.Controllers
{
    public class QuestionsController : ApiController
    {
        CompetencesmsEntitiesQ db = new CompetencesmsEntitiesQ();

        [HttpGet]
        public IHttpActionResult GetList()
        {
            return Ok(db.Questions.ToList());
        }

        [HttpGet]
        public IHttpActionResult GetQuestion(int id)
        {
            return Ok(db.Questions.Find(id));
        }

    }
}
