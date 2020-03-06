using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.ModelViews;

namespace LibraryApp.BusinessLayer
{
    public class UserManager
    {
        public User RegisterUser(User user)
        {

            Repository<User>  repositoryUser = new Repository<User>();

            var resultUser = repositoryUser.Find(x => x.Email == user.Email || x.Username == user.Username);

            if (resultUser != null)
            {
                repositoryUser.Insert(resultUser);
                
            }

            return resultUser;
        }
    }
}
