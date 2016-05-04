using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication4.DAL;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers
{
    public class PaintingsController : ApiController
    {
        ///private MuseumContext db = new MuseumContext();
        ///
        private readonly IPaintingsRepository _paintingsRepo;
        private readonly ILogger _logger;

        // GET: api/Paintings
        public IEnumerable<Painting> GetPaintings()
        {
            _logger.Write("GET ALL for Paintings was called", LogLevel.INFO);

            return _paintingsRepo.GetAll();
        }

        // GET: api/Paintings/5
        [ResponseType(typeof(Painting))]
        public IHttpActionResult GetPainting(int id)
        {
            _logger.Write("GET for Paintings was called", LogLevel.INFO);

            Painting painting = _paintingsRepo.Get(id);
            if (painting == null)
            {
                return NotFound();
            }

            return Ok(painting);
        }

        // PUT: api/Paintings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPainting(int id, Painting painting)
        {
            _logger.Write("PUT for Paintings was called", LogLevel.INFO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != painting.Id)
            {
                return BadRequest();
            }

            Painting a = _paintingsRepo.Update(painting);

            if (a == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Paintings
        [ResponseType(typeof(Painting))]
        public IHttpActionResult PostPainting(Painting painting)
        {
            _logger.Write("POST for Paintings was called", LogLevel.INFO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _paintingsRepo.Add(painting);

            return CreatedAtRoute("DefaultApi", new { id = painting.Id }, painting);
        }

        // DELETE: api/Paintings/5
        [ResponseType(typeof(Painting))]
        public IHttpActionResult DeletePainting(int id)
        {
            _logger.Write("DELETE for Paintings was called", LogLevel.INFO);

            Painting painting = _paintingsRepo.Get(id);
            if (painting == null)
            {
                return NotFound();
            }

            _paintingsRepo.Delete(id);

            return Ok(painting);
        }
    }
}