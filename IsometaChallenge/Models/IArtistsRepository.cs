using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IsometaChallenge.Models
{
    public interface IArtistsRepository
    {
        List<Artist> GetAll();
        void Add( Artist model );
        void Update( Artist model );
        Artist GetById( int id );
    }

    public class DbArtistsRepository : IArtistsRepository
    {

        private MusicContext db = new MusicContext();
        public List<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        public void Add( Artist model )
        {
            db.Artists.Add( model );
            db.SaveChanges();
        }

        public void Update( Artist model )
        {
            db.Entry( model ).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Artist GetById( int id )
        {
            return db.Artists.Find( id );
        }
    }
}