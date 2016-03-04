using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IsometaChallenge.Models;

namespace IsometaChallenge.Controllers
{
    public class ArtistController : Controller
    {
        readonly IArtistsRepository repositoryArtist = new DbArtistsRepository();
        readonly IGenreRepository repositoryGenre = new DBGenreRepository();
        
        public ActionResult Index()
        {
            var artists = AutoMapper.Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistViewModel>>( repositoryArtist.GetAll() );
            return View( artists );
        }

        public ActionResult Create()
        {
            ArtistViewModel model = new ArtistViewModel();
            model.Genres = GetAllCategories();
            return View( model );
        }

        [HttpPost]
        public ActionResult Create( ArtistViewModel model )
        {
            try
            {
                if( ModelState.IsValid )
                {
                    var artist = AutoMapper.Mapper.Map<ArtistViewModel, Artist>( model );
                    repositoryArtist.Add( artist );
                    return RedirectToAction( "Index" );
                }
            }
            catch( Exception e )
            {
                ModelState.AddModelError( string.Empty, "Unable to save changes." );
            }
            return View( model );
        }

        public ActionResult Edit( int id )
        {
            var model = AutoMapper.Mapper.Map<Artist, ArtistViewModel>( repositoryArtist.GetById( id ) );
            model.Genres = GetAllCategories();
            return View( model );
        }

        [HttpPost]
        public ActionResult Edit( int id, ArtistViewModel model )
        {
            try
            {
                if( ModelState.IsValid )
                {
                    var hero = AutoMapper.Mapper.Map<ArtistViewModel, Artist>( model );
                    hero.ArtistId = id;
                    repositoryArtist.Update( hero );
                    return RedirectToAction( "Index" );
                }
            }
            catch( Exception e )
            {
                ModelState.AddModelError( string.Empty, "Unable to save changes." );
            }
            return View( model );
        }

        private List<SelectListItem> GetAllCategories()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach( var res in repositoryGenre.GetAll() )
            {
                result.Add( new SelectListItem { Text = res.Name, Value = res.GenreId.ToString() } );
            }
            return result;
        }
    }
}
