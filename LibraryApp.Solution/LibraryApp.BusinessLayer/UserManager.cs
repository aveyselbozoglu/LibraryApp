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

            var resultUser = repositoryUser.Find(x =>
                x.Email == registerViewModel.Email || x.Username == registerViewModel.Username);

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

            var resultUser = repositoryUser.Find(x =>
                x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);

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

        public BusinessLayerResult<User> GetUserById(int? id)
        {
            BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();
            Repository<User> repositoryUser = new Repository<User>();

            // deneme

            //Repository<Borrow> repositoryBorrow = new Repository<Borrow>();
            //var borrowsByUserId =repositoryBorrow.Find(x => x.User.Id == id);

            //if (borrowsByUserId != null)
            //{
            //    return borrowsByUserId;
            //}

            // denemeson

            businessLayerResult.BlResult = repositoryUser.Find(x => x.Id == id);

            if (businessLayerResult.BlResult == null)
            {
                businessLayerResult.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı.");
            }

            return businessLayerResult;
        }

        public BusinessLayerResult<User> RemoveUserById(int id)
        {
            BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();
            Repository<User> repositoryUser = new Repository<User>();

            businessLayerResult.BlResult = repositoryUser.Find(x => x.Id == id);

            if (businessLayerResult.BlResult != null)
            {
                repositoryUser.Delete(businessLayerResult.BlResult);
            }
            else
            {
                businessLayerResult.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı");
            }

            return businessLayerResult;
        }

        //public List<Borrow> GetBorrowsByUserId(int? id)
        //{
        //    BusinessLayerResult<Borrow> businessLayerResult = new BusinessLayerResult<Borrow>();
        //    Repository<Borrow> repositoryBorrow = new Repository<Borrow>();
        //    var borrowsByUserId = repositoryBorrow.List(x => x.User.Id == id.Value);

        //    return borrowsByUserId;
        //}

        public BusinessLayerResult<User> UpdateUser(User user)
        {
            Repository<User> repositoryUser = new Repository<User>();
            BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();

            businessLayerResult.BlResult = repositoryUser.Find(x => x.Id == user.Id && (x.Email == user.Email));

            if (businessLayerResult.BlResult == null)
            {
                //
                businessLayerResult.AddError(ErrorMessageCode.UserNotFound, "Böyle bir kullanıcı bulunamadı");
            }
            else
            {
                businessLayerResult.BlResult.Email = user.Email;
                businessLayerResult.BlResult.Name = user.Name;
                businessLayerResult.BlResult.Surname = user.Surname;
                businessLayerResult.BlResult.Password = user.Password;
                businessLayerResult.BlResult.ProfileImageFileName = user.ProfileImageFileName;
                businessLayerResult.BlResult.Username = user.Username;

                repositoryUser.Update(businessLayerResult.BlResult);
            }

            return businessLayerResult;
        }
    }
}