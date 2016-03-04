using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsometaChallenge.Models
{
    public class ArtistViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public string Instrument { get; set; }
        [Display(Name = "Record Label")]
        public string RecordLabel { get; set; }
        [Display(Name= "Genre" )]
        public int? GenreId { get; set; }
        [Display(Name= "Genre Name" )]
        public string GenreName { get; set; }
        public List<SelectListItem> Genres { get; set; }
    }
}