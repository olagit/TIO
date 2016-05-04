using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using WebApplication4.Services.Models;
using LiteDB;

namespace WebApplication4.Services.LiteDB
{
    public class ArtistsRepository : IArtistsRepository
    {
        private readonly string _artistConnection = DatabaseConnections.ArtistConnection;

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<ArtistDB>("artists");
                if (repository.FindById(artist.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<ArtistDB>("artists");
                return repository.Delete(id);
            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<ArtistDB>("artists");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<ArtistDB>("artists");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<ArtistDB>("artists");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        internal Artist Map(ArtistDB dbArtist)
        {
            if (dbArtist == null)
                return null;
            return new Artist() { Id = dbArtist.Id, ArtistName = dbArtist.ArtistName, ArtistSurname = dbArtist.ArtistSurname };
        }

        internal ArtistDB InverseMap(Artist Artist)
        {
            if (Artist == null)
                return null;
            return new ArtistDB() { Id = Artist.Id, ArtistName = Artist.ArtistName, ArtistSurname = Artist.ArtistSurname };
        }
    }
}