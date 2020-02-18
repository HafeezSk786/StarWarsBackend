using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string BirthYear { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string EyeColor { get; set; }
        public string Gender { get; set; }
        public string HairColor { get; set; }
        public string Height { get; set; }
        public int HomeWorld { get; set; }
        public string Mass { get; set; }
        public string Name { get; set; }
        public string SkinColor { get; set; }
        public int Count { get; set; }
    }
}
