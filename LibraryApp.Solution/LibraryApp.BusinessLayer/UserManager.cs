using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.Messages;
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
                    //businessLayerResult.ErrorMessageObj.Add(new ErrorMessageObj()
                    //{
                    //    Code = ErrorMessageCode.EmailAlreadyUsed,
                    //    Message = "Bu email kullanılıyor"
                    //});

                    businessLayerResult.AddError(ErrorMessageCode.EmailAlreadyUsed, "Bu email kullanılıyor");




                }
                if (resultUser.Username == registerViewModel.Username)
                {
                    businessLayerResult.ErrorMessageObj.Add(new ErrorMessageObj()
                    {
                        Code = ErrorMessageCode.UsernameAlreadyUsed,
                        Message = "Bu kullanıcı adı kullanılıyor"
                    });

                    businessLayerResult.AddError(ErrorMessageCode.UsernameAlreadyUsed, "Bu kullanıcı adı kullanılıyor");

                    //businessLayerResult.Errors.Add("Bu kullanıcı adı kullanılıyor");
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

        public BusinessLayerResult<User> LoginUser(LoginViewModel loginViewModel)
        {
            Repository<User> repositoryUser = new Repository<User>();
            BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();

            var resultUser = repositoryUser.Find(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);

            if (resultUser == null)
            {
                //  blResult.Errors.Add("Bu E-posta adresi kullanılmaktadır.");

                //businessLayerResult.ErrorMessageObj.Add(new ErrorMessageObj()
                //{

                //    Code = ErrorMessageCode.EmailOrPassWrong,
                //    Message = "Böyle bir kayıt bulunmamaktadır."
                //});

                businessLayerResult.AddError(ErrorMessageCode.EmailOrPassWrong, "Böyle bir kayıt bulunmamaktadır");
            }

            businessLayerResult.BlResult = resultUser;

            return businessLayerResult;
        }
    }
}