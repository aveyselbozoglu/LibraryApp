using LibraryApp.DataAccessLayer.EntityFramework;
using LibraryApp.Entities;
using LibraryApp.Entities.Messages;
using LibraryApp.Entities.ModelViews;

namespace LibraryApp.BusinessLayer
{
    public class AddressManager
    {
        private Repository<User> repositoryUser = new Repository<User>();
        private Repository<Address> repositoryAddress = new Repository<Address>();
        private BusinessLayerResult<Address> businessLayerResult = new BusinessLayerResult<Address>();

        public BusinessLayerResult<Address> AddAddressForUser(AddressViewModel addressViewModel, User user)
        {
            User checkUser = repositoryUser.Find(x => x.Id == user.Id);

            if (checkUser != null)
            {
                Address newAddress = new Address()
                {
                    Street = addressViewModel.Street,
                    BuildingNo = addressViewModel.BuildingNo,
                    City = addressViewModel.City,
                    District = addressViewModel.District,
                    Owner = user
                };

                int checkInserted = repositoryAddress.Insert(newAddress);

                if (checkInserted != 1)
                {
                    businessLayerResult.AddError(ErrorMessageCode.AddressCouldNotInserted, "Adres eklenemedi");
                }
                else
                {
                    businessLayerResult.BlResult = newAddress;
                }
            }

            return businessLayerResult;
        }

        public BusinessLayerResult<Address> GetAllAddressesByUserId(int? id)
        {
            if (id != null)
            {
                var checkAddresses = new Repository<Address>().List(x => x.UserId == id);
                if (checkAddresses == null)
                {
                    businessLayerResult.AddError(ErrorMessageCode.NoAddressForUser, "Kullanıcıya ait adres bulunamadı");

                    return businessLayerResult;
                }

                businessLayerResult.BlResultList = checkAddresses;
            }

            return businessLayerResult;
        }

        public BusinessLayerResult<Address> RemoveAddressById(int id)
        {
            businessLayerResult.BlResult = repositoryAddress.Find(x => x.Id == id);
            if (businessLayerResult.BlResult != null)
            {
                repositoryAddress.Delete(businessLayerResult.BlResult);
            }
            else
            {
                businessLayerResult.AddError(ErrorMessageCode.AddressCouldNotDeleted, "Adres silinemedi");
            }

            return businessLayerResult;
        }
    }
}