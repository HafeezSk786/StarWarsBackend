using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StarWars.DAL;
using StarWars.Models;

namespace StarWars.Data
{
    public class StarWarsContext
    {
        public List<Film> GetOpeningCrawl()
        {
            List<Film> objFilmList = new List<Film>();   //create model list
            try
            {
                StarWarsDAL objDAL = new StarWarsDAL();
                objFilmList = objDAL.GetFilmList();     //fetch required details
                return objFilmList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> GetMostAppearedPerson()
        {
            List<Person> objPersonList = new List<Person>();
            try
            {
                StarWarsDAL objDAL = new StarWarsDAL();
                objPersonList = objDAL.GetPersonAppeared();  //fetch required details
                return objPersonList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Species> GetMostAppearedSpecies()
        {
            List<Species> objSpeciesList = new List<Species>();
            try
            {
                StarWarsDAL objDAL = new StarWarsDAL();
                objSpeciesList = objDAL.GetSpeciesAppeared();  //fetch required details
                return objSpeciesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Planet> GetVehiclePilots()
        {
            List<Planet> objPilotsList = new List<Planet>();
            try
            {
                StarWarsDAL objDAL = new StarWarsDAL();
                objPilotsList = objDAL.GetVehiclePilots();  //fetch required details
                return objPilotsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
