using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using LibraryApp.Entities.ModelViews;
using LibraryApp.WebApp.NotifyModels;
using System.Web.Mvc;

namespace LibraryApp.WebApp.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress(AddressViewModel addressViewModel)
        {
            if (ModelState.IsValid)
            {
                AddressManager addressManager = new AddressManager();
                BusinessLayerResult<Address> businessLayerResult = new BusinessLayerResult<Address>();
                User currentUser = Session["login"] as User;

                businessLayerResult = addressManager.AddAddressForUser(addressViewModel, currentUser);
                if (businessLayerResult.ErrorMessageObj.Count > 0)
                {
                    ErrorViewModel errorViewModel = new ErrorViewModel()
                    {
                        Title = "Adres eklenemedi",
                        RedirectingUrl = "User/ShowProfile",
                        Items = businessLayerResult.ErrorMessageObj
                    };
                    return View("Error", errorViewModel);
                }
                else
                {
                    OkViewModel okViewModel = new OkViewModel()
                    {
                        Title = "Adres başarıyla eklendi"
                    };
                    return View("Ok", okViewModel);
                }
            }

            return View(addressViewModel);
        }

        public ActionResult RemoveAddressById(int id)
        {
            var businessLayerResultAddress = new AddressManager().RemoveAddressById(id);

            if (businessLayerResultAddress.ErrorMessageObj.Count > 0)
            {
                ErrorViewModel errorViewModel = new ErrorViewModel()
                {
                    Items = businessLayerResultAddress.ErrorMessageObj,
                    RedirectingUrl = "/User/ShowProfile"
                };
                return View("Error", errorViewModel);
            }

            OkViewModel okViewModel = new OkViewModel()
            {
                RedirectingUrl = "/User/ShowProfile",
            };
            return View("Ok", okViewModel);
        }
    }
}