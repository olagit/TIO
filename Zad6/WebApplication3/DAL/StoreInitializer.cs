using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication3.Models;

namespace WebApplication3.DAL
{
    public class StoreInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext sc)
        {
            Author a1 = new Author() { Id = 1, AuthorName = "Qwert", AuthorSurname = "Yuiop" };
            Author a2 = new Author() { Id = 2, AuthorName = "Asdf", AuthorSurname = "Ghjkl" };

            Book b1 = new Book() { Id = 1, BookTitle = "Zxc", ISBN = "1234567899999" };
            Book b2 = new Book() { Id = 2, BookTitle = "Bnm", ISBN = "1111222233334" };
            Book b3 = new Book() { Id = 3, BookTitle = "Vvv", ISBN = "1231231231231" };

            sc.Authors.Add(a1);
            sc.Authors.Add(a2);

            sc.Books.Add(b1);
            sc.Books.Add(b2);
            sc.Books.Add(b3);

            sc.SaveChanges();
        }
    }
}