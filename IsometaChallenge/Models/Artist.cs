using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        public string RecordLabel { get; set; }
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}