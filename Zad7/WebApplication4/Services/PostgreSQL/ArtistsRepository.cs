using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using WebApplication4.DAL;
using WebApplication4.Services.Models;

namespace WebApplication4.Services.PostgreSQL
{
    public class ArtistsRepository : IArtistsRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();

            return artist.Id;
        }

        public bool Delete(int id)
        {
            Artist a = db.Artists.Find(id);
            if (a == null)
            {
                return false;
            }

            db.Artists.Remove(a);
            db.SaveChanges();

            return true;
        }

        public Artist Get(int id)
        {
            return db.Artists.Find(id);
        }

        public List<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        public Artist Update(Artist artist)
        {
            Artist a = db.Artists.Find(artist.Id);

            if (a == null)
            {
                return null;
            }

            a = artist;
            db.SaveChanges();

            return a;
        }
    }
}