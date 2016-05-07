using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library
{
    class GamesInitializer : DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            Game g1 = new Game() { Id = 1, Title = "t1", CreatorCompany = "c1", Year = 2001, AgeRate = 11 };
            Game g2 = new Game() { Id = 2, Title = "t2", CreatorCompany = "c2", Year = 2002, AgeRate = 12 };
            Game g3 = new Game() { Id = 3, Title = "t3", CreatorCompany = "c3", Year = 2003, AgeRate = 13 };
            Game g4 = new Game() { Id = 4, Title = "t4", CreatorCompany = "c4", Year = 2004, AgeRate = 14 };
            Game g5 = new Game() { Id = 5, Title = "t5", CreatorCompany = "c5", Year = 2005, AgeRate = 15 };

            Store s1 = new Store() { Id = 1, Name = "n1", Address = "a1" };
            Store s2 = new Store() { Id = 2, Name = "n2", Address = "a2" };
            Store s3 = new Store() { Id = 3, Name = "n3", Address = "a3" };
            Store s4 = new Store() { Id = 4, Name = "n4", Address = "a4" };
            Store s5 = new Store() { Id = 5, Name = "n5", Address = "a5" };

            context.Games.Add(g1);
            context.Games.Add(g2);
            context.Games.Add(g3);
            context.Games.Add(g4);
            context.Games.Add(g5);

            context.Stores.Add(s1);
            context.Stores.Add(s2);
            context.Stores.Add(s3);
            context.Stores.Add(s4);
            context.Stores.Add(s5);

            context.SaveChanges();
            //base.Seed(context);
        }
        }
    }
