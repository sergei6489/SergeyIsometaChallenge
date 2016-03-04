﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}