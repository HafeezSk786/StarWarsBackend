﻿using System;
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

        public List<Person> GetPersonAppeared()
        {
            List<Person> personList = new List<Person>();
            try
            {
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
                SpeciesList = (from s in dbContext.species
                                 join fs in dbContext.films_species on s.id equals fs.species_id
                                 join f in dbContext.films on fs.film_id equals f.id
                                 join fc in dbContext.films_characters on f.id equals fc.film_id
                                 join p in dbContext.peoples on fc.people_id equals p.id
                                 group f by new { f.id, s.name } into g
                                 select new Species
                                 {
                                     Name = g.Key.name,
                                     Count = g.Count(),
                                 }).OrderByDescending(y => y.Count).ToList<Species>();
                return SpeciesList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
