using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiteDB;
using WebApplication4.Models;
using WebApplication4.Services.Models;

namespace WebApplication4.Services.LiteDB
{
    public class PaintingsRepository
    {
        private readonly string _paintingConnection = DatabaseConnections.PaintingConnection;

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<PaintingDB>("paintings");
                if (repository.FindById(painting.Id) != null)
                    repository.Update(dbObject);
                else
                    repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<PaintingDB>("paintings");
                return repository.Delete(id);
            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<PaintingDB>("paintings");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<PaintingDB>("paintings");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<PaintingDB>("paintings");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        internal Painting Map(PaintingDB dbPainting)
        {
            if (dbPainting == null)
                return null;
            return new Painting() { Id = dbPainting.Id, Title = dbPainting.Title, Year = dbPainting.Year };
        }

        internal PaintingDB InverseMap(Painting painting)
        {
            if (painting == null)
                return null;
            return new PaintingDB() { Id = painting.Id, Title = painting.Title, Year = painting.Year };

        }
    }
}