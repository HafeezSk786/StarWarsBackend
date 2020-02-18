using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StarWars.Models;

namespace StarWars.DAL
{
    public class StarWarsDAL
    {
        StarWarsClassDataContext dbContext = new StarWarsClassDataContext();

        public List<Film> GetFilmList()
        {
            List<Film> filmList = new List<Film>();
            try
            {
                var query = (from f in dbContext.films
                         join fc in dbContext.films_characters on f.id equals fc.film_id
                         join p in dbContext.peoples on fc.people_id equals p.id
                         group f by f.title into g
                         select new Film
                         {
                             Title=g.Key, 
                             Count=g.Count()
                         }).OrderByDescending(y=>y.Count).FirstOrDefault();
                filmList.Add(query);
                return filmList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
