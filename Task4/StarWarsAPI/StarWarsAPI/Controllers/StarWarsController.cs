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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [Route("api/StarWars/GetCrawls")]
        [HttpGet]
        public IHttpActionResult GetOpeningCrawl()
        {
            //Create context object.
            StarWarsContext _context = new StarWarsContext();
            try
            {
                log.Info("GetOpeningCrawl Method start");
                List<Film> objFilmList = _context.GetOpeningCrawl(); //method to fetch required details
                return Ok(objFilmList);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message); //exception logging
                return BadRequest("Error in fetching the details");
            }
        }

        [Route("api/StarWars/MostAppearedPerson")]
        [HttpGet]
        public IHttpActionResult GetMostAppearedPerson()
        {
            StarWarsContext _context = new StarWarsContext();
            try
            {
                log.Info("GetMostAppeared Method start");
                List<Person> objPersonList = _context.GetMostAppearedPerson(); //method to fetch required details
                return Ok(objPersonList);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message); //exception logging
                return BadRequest("Error in fetching the details");
            }
        }

        [Route("api/StarWars/MostAppearedSpecies")]
        [HttpGet]
        public IHttpActionResult GetMostAppearedSpecies()
        {
            StarWarsContext _context = new StarWarsContext();
            try
            {
                log.Info("GetMostAppearedSpecies Method start");
                List<Species> objSpeciesList = _context.GetMostAppearedSpecies(); //method to fetch required details
                return Ok(objSpeciesList);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message); //exception logging
                return BadRequest("Error in fetching the details");
            }
        }

        [Route("api/StarWars/VehiclePilots")]
        [HttpGet]
        public IHttpActionResult GetVehiclePilots()
        {
            StarWarsContext _context = new StarWarsContext();
            try
            {
                log.Info("GetVehiclePilots Method start");
                List<Planet> objPilotsList = _context.GetVehiclePilots(); //method to fetch required details
                return Ok(objPilotsList);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message); //exception logging
                return BadRequest("Error in fetching the details");
            }
        }
    }
}
