using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using StarWars.Data;
using StarWars.Models;

namespace StarWarsAPI.Controllers
{
    public class StarWarsController : ApiController
    {
        [Route("api/StarWars/GetCrawls")]
        [HttpGet]
        public IHttpActionResult GetOpeningCrawl()
        {
            StarWarsContext _context = new StarWarsContext();
            try
            {
                List<Film> objFilmList = _context.GetOpeningCrawl();
                return Ok(objFilmList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
