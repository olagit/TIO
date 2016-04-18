using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectsManager.Models;
using ObjectsManager.LiteDBAuthor;

namespace WebApplication2.Controllers
{
    public class AuthorsController : ApiController
    {
        AuthorRepository ar = new AuthorRepository();

        public IEnumerable<Author> Get()
        {
            return ar.GetAll();
        }

        public Author Get(int id)
        {
            return ar.Get(id);
        }

        public void Post([FromBody] Author a)
        {
            ar.Add(a);
        }

        public void Put(int id, [FromBody] Author a)
        {
            ar.Update(a);
        }

        public void Delete(int id)
        {
            ar.Delete(id);
        }

    }
}
