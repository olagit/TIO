using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using System.Data.Entity;

namespace WebApplication4.DAL
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext mc)
        {
            Artist a1 = new Artist() { Id = 1, ArtistName = "Aaa", ArtistSurname = "Bbb" };
            Artist a2 = new Artist() { Id = 2, ArtistName = "Ccc", ArtistSurname = "Ddd" };

            Painting p1 = new Painting() { Id = 1, Title = "Eee", Year = 1234 };
            Painting p2 = new Painting() { Id = 2, Title = "Fff", Year = 2016 };
            Painting p3 = new Painting() { Id = 3, Title = "Ggg", Year = 9999 };

            mc.Artists.Add(a1);
            mc.Artists.Add(a2);

            mc.Paintings.Add(p1);
            mc.Paintings.Add(p2);
            mc.Paintings.Add(p3);

            mc.SaveChanges();
        }
    }
}