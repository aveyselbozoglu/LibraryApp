using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Entities;

namespace LibraryApp.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var user = new User()
            {
                Name = "John",
                Surname = "Thomas",
                IsAdmin = true,
                Email = "johnthomas@gmail.com",
                Password = "123",
                ProfileImageFileName = "eagle.png",
                Username = "jthomas"
                
            };
            var user2 = new User()
            {
                Name = "Michael",
                Surname = "James",
                IsAdmin = true,
                Email = "michaeljames@gmail.com",
                Password = "1232",
                ProfileImageFileName = "hawk.jpg",
                Username = "mjames"

            };
            context.Users.Add(user);
            context.Users.Add(user2);
            context.SaveChanges();
        }
    }
}
