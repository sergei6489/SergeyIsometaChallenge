using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();
        void Add( Genre model );
        void Update( Genre model );
        Genre GetById( int id );
    }

    public class DBGenreRepository : IGenreRepository
    {
        private MusicContext db = new MusicContext();
        public IEnumerable<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public void Add( Genre model )
        {
            db.Genres.Add( model );
            db.SaveChanges();
        }

        public void Update( Genre model )
        {
            db.Entry( model ).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Genre GetById( int id )
        {
            return db.Genres.Find( id );
        }
    }
}