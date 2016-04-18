using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ObjectsManager.Models;
using ObjectsManager.LiteDBBook;

namespace WebApplication2.Controllers
{
    public class BooksController : ApiController
    {
        BookRepository br = new BookRepository();

        public IEnumerable<Book> Get()
        {
            return br.GetAll();
        }

        public Book Get(int id)
        {
            return br.Get(id);
        }

        public IEnumerable<Book> Get(string search)
        {
            return br.GetAll().Where(x => x.BookTitle.Contains(search));
        }

        public void Post([FromBody] Book b)
        {
            br.Add(b);
        }

        public void Put(int id, [FromBody] Book b)
        {
            br.Update(b);
        }

        public void Delete(int id)
        {
            br.Delete(id);
        }
    }
}
