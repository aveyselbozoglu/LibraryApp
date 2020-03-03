using System.Collections.Generic;
using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;

namespace LibraryApp.BusinessLayer
{
    public class UserManager
    {
        public UserManager()
        {

            Repository<User> repo_user = new Repository<User>();
            repo_user.List();
            Repository<Address> repo_adres = new Repository<Address>();

            //repo_user.Insert(new User()
            //{
            //    Name = "a",
            //    Email = "asd",
            //    Surname = "a",
            //    IsAdmin = true,
            //    Password = "a",
            //    Username = "asd",
            //});

            User q = new User()
            {
                Name = "sada",
                Email = "asdasdasd",
                Surname = "aasdad",
                IsAdmin = true,
                Password = "aasdad",
                Username = "aasdasdasdsd",
            };


            repo_user.Insert(q);

            //var testUser = repo_user.Find(x => x.Id == 1);

            Address address = new Address()
            {
                BuildingNo = "test",
                City = "test",
                District = "test",
                Street = "test",
                Owner = q
            };

            repo_adres.Insert(address);
            

        }

        public List<User> GetUserList()
        {
            List<User> q = new List<User>();
            Repository<User> repo_user = new Repository<User>();
            q= repo_user.List();
            
            return q;
        }
        
    }
}