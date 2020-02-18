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
                //query to fetch Star Wars movie which has the longest opening crawl (counted by number  of characters).
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

        public List<Person> GetPersonAppeared()
        {
            List<Person> personList = new List<Person>();
            try
            {
                //query to fetch  character (person) appeared in most of the Star Wars films.
                var query = (from fc in dbContext.films_characters
                             join f in dbContext.films on fc.film_id equals f.id
                             join p in dbContext.peoples on fc.people_id equals p.id
                             group p by p.id into g
                             select new Person
                             {
                                 Id = g.Key,
                                 Name= g.Select(x => x.name).FirstOrDefault(),
                                 Count = g.Count()
                             }).OrderByDescending(y => y.Count).FirstOrDefault();
                personList.Add(query);
                return personList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Species> GetSpeciesAppeared()
        {
            List<Species> SpeciesList = new List<Species>();
            try
            {
                //query to fetch species (i.e. characters that belong to certain species) appeared in the most  number of Star Wars films.
                SpeciesList = (from f in dbContext.films
                               join fs in dbContext.films_species on f.id equals fs.film_id
                               join sp in dbContext.species_peoples on fs.species_id equals sp.species_id
                               join s in dbContext.species on sp.species_id equals s.id
                               join fc in dbContext.films_characters on sp.people_id equals fc.people_id
                               group f by new { f.id, s.name } into g
                               select new Species
                                 {
                                       Name = g.Key.name,
                                       Count = g.Select(x=>x.films_species.Count).Count()  
                                 }).OrderByDescending(y => y.Count).ToList<Species>();
                return SpeciesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Planet> GetVehiclePilots()
        {
            List<Planet> PilotsList = new List<Planet>();
            try
            {
                //query to fetch planet in Star Wars universe provided largest number of vehicle pilots.
                PilotsList = (from pl in dbContext.planets
                              join fp in dbContext.films_planets on pl.id equals fp.planet_id
                              join f in dbContext.films on fp.film_id equals f.id
                              join fs in dbContext.films_species on fp.film_id equals fs.film_id
                              join s in dbContext.species on fs.species_id equals s.id
                              join sp in dbContext.species_peoples on s.id equals sp.species_id
                              join p in dbContext.peoples on sp.people_id equals p.id
                              join vp in dbContext.vehicles_pilots on p.id equals vp.people_id
                              group pl by new { planetname=pl.name,personname=p.name,speciesname=s.name } into g
                              select new Planet
                              {
                                  Name = g.Key.planetname,
                                  PersonName=g.Key.personname,
                                  SpeciesName=g.Key.speciesname,
                                  Count = g.Count()
                               }).OrderByDescending(y => y.Count).ToList<Planet>();
                                            
                return PilotsList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
