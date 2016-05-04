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
    public class ArtistsController : ApiController
    {
        private readonly IArtistsRepository _artistsRepo;
        private readonly ILogger _logger;

        // GET: api/Artists
        public IEnumerable<Artist> GetArtists()
        {
            _logger.Write("GET ALL for Artists was called", LogLevel.INFO);

            return _artistsRepo.GetAll();
        }

        // GET: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult GetArtist(int id)
        {
            _logger.Write("GET for Artists was called", LogLevel.INFO);

            Artist artist = _artistsRepo.Get(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArtist(int id, Artist artist)
        {
            _logger.Write("PUT for Artists was called", LogLevel.INFO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            Artist a = _artistsRepo.Update(artist);

            if (a == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Artists
        [ResponseType(typeof(Artist))]
        public IHttpActionResult PostArtist(Artist artist)
        {
            _logger.Write("POST for Artists was called", LogLevel.INFO);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _artistsRepo.Add(artist);

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [ResponseType(typeof(Artist))]
        public IHttpActionResult DeleteArtist(int id)
        {
            _logger.Write("DELETE for Artists was called", LogLevel.INFO);

            Artist artist = _artistsRepo.Get(id);
            if (artist == null)
            {
                return NotFound();
            }

            _artistsRepo.Delete(id);

            return Ok(artist);
        }
    }
}