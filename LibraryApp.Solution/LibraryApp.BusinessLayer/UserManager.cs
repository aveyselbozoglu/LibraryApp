using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.ModelViews;

namespace LibraryApp.BusinessLayer
{
    public class UserManager
    {
        public BusinessLayerResult<User> RegisterUser(RegisterViewModel registerViewModel)
        {
            Repository<User> repositoryUser = new Repository<User>();
            BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();


            var resultUser = repositoryUser.Find(x => x.Email == registerViewModel.Email || x.Username == registerViewModel.Username);

            if (resultUser != null)
            {

                if (resultUser.Email == registerViewModel.Email)
                {
                    businessLayerResult.Errors.Add("Bu email kullanılıyor");
                }
                if (resultUser.Username == registerViewModel.Username)
                {
                    businessLayerResult.Errors.Add("Bu kullanıcı adı kullanılıyor");
                }

            }
            else
            {
                var newUser = new User()
                {
                    Email = registerViewModel.Email,
                    Username = registerViewModel.Username,
                    Name = registerViewModel.Name,
                    Surname = registerViewModel.Surname,
                    Password = registerViewModel.Password
                };

                var isUserInserted = repositoryUser.Insert(newUser);
                

                if (isUserInserted > 0)
                {
                    businessLayerResult.BlResult = newUser;
                }


            }

            return businessLayerResult;
        }
    }
}