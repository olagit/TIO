using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Library;

namespace WebApplication6.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Library;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Store>("Stores");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StoresController : ODataController
    {
        private GamesContext db = new GamesContext();

        // GET: odata/Stores
        [EnableQuery]
        public IQueryable<Store> GetStores()
        {
            return db.Stores;
        }

        // GET: odata/Stores(5)
        [EnableQuery]
        public SingleResult<Store> GetStore([FromODataUri] int key)
        {
            return SingleResult.Create(db.Stores.Where(store => store.Id == key));
        }

        // PUT: odata/Stores(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Store> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Store store = db.Stores.Find(key);
            if (store == null)
            {
                return NotFound();
            }

            patch.Put(store);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(store);
        }

        // POST: odata/Stores
        public IHttpActionResult Post(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stores.Add(store);
            db.SaveChanges();

            return Created(store);
        }

        // PATCH: odata/Stores(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Store> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Store store = db.Stores.Find(key);
            if (store == null)
            {
                return NotFound();
            }

            patch.Patch(store);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(store);
        }

        // DELETE: odata/Stores(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Store store = db.Stores.Find(key);
            if (store == null)
            {
                return NotFound();
            }

            db.Stores.Remove(store);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int key)
        {
            return db.Stores.Count(e => e.Id == key) > 0;
        }
    }
}
