using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        [DisplayName( "Count Artists" )]
        public int CountArtists { get; set; }
    }
}