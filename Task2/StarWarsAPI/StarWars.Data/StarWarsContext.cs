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
            List<Film> objFilmList = new List<Film>();
            try
            {
                StarWarsDAL objDAL = new StarWarsDAL();
                objFilmList = objDAL.GetFilmList();
                return objFilmList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Person> GetMostAppearedPerson()
        {
            List<Person> objPersonList = new List<Person>();
            try
            {
                StarWarsDAL objDAL = new StarWarsDAL();
                objPersonList = objDAL.GetPersonAppeared();
                return objPersonList;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
