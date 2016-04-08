using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class Movie
    {
        public int Id;
        public string Title;
        public int ReleaseYear;
    }

    public class Review
    {
        public int Id;
        public string Content;
        public int Score;
        public Person Author;
        public int MovieId;
    }

    public class Person
    {
        public int Id;
        public string Name;
        public string Surname;
    }


}
