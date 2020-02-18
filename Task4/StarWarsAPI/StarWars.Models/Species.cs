﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Models
{
    public class Species
    {
        public int Id { get; set; }
        public string AverageHeight { get; set; }
        public string AverageLifeSpan { get; set; }
        public string Classification { get; set; }
        public DateTime Created { get; set; }
        public string Designation { get; set; }
        public DateTime Edited { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public int HomeWorld { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string SkinColor { get; set; }
        public int Count { get; set; }
        public int FilmId { get; set; }
    }
}