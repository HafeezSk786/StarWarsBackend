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
        public List<StarWars.Models.Film> GetOpeningCrawl()
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
    }
}
