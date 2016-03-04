using IsometaChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IsometaChallenge.Controllers
{
    public class GenreController : Controller
    {
        readonly IGenreRepository repository = new DBGenreRepository();
        // GET: Superhero
        public ActionResult Index()
        {
            var artists = AutoMapper.Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>( repository.GetAll() );
            return View( artists );
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        public ActionResult Create( GenreViewModel model )
        {
            try
            {
                if( ModelState.IsValid )
                {
                    var artist = AutoMapper.Mapper.Map<GenreViewModel, Genre>( model );
                    repository.Add( artist );
                    return RedirectToAction( "Index" );
                }
            }
            catch( Exception e )
            {
                ModelState.AddModelError( string.Empty, "Unable to save changes." );
            }
            return View( model );
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit( int id )
        {
            var model = AutoMapper.Mapper.Map<Genre, GenreViewModel>( repository.GetById( id ) );
            return View( model );
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        public ActionResult Edit( int id, GenreViewModel model )
        {
            try
            {
                if( ModelState.IsValid )
                {
                    var hero = AutoMapper.Mapper.Map<GenreViewModel, Genre>( model );
                    repository.Update( hero );
                    return RedirectToAction( "Index" );
                }
            }
            catch( Exception e )
            {
                ModelState.AddModelError( string.Empty, "Unable to save changes." );
            }
            return View( model );
        }
    }
}