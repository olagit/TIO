using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using WebApplication4.DAL;
using WebApplication4.Services.Models;

namespace WebApplication4.Services.PostgreSQL
{
    public class PaintingsRepository : IPaintingsRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();

            return painting.Id;
        }

        public bool Delete(int id)
        {
            Painting a = db.Paintings.Find(id);
            if (a == null)
            {
                return false;
            }

            db.Paintings.Remove(a);
            db.SaveChanges();

            return true;
        }

        public Painting Get(int id)
        {
            return db.Paintings.Find(id);
        }

        public List<Painting> GetAll()
        {
            return db.Paintings.ToList();
        }

        public Painting Update(Painting painting)
        {
            Painting a = db.Paintings.Find(painting.Id);

            if (a == null)
            {
                return null;
            }

            a = painting;
            db.SaveChanges();

            return a;
        }
    }
}