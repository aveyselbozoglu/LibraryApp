using LibraryApp.Entities.Messages;
using System.Collections.Generic;

namespace LibraryApp.WebApp.NotifyModels
{
    public class OkViewModel : NotifyViewModelBase<ErrorMessageObj>
    {
        public OkViewModel()
        {
            Items = new List<ErrorMessageObj>();
            Header = "Yönlendiriliyorsunuz..";
            Title = "Başarılı İşlem";
            IsRedirecting = true;
            RedirectingUrl = "/Home/Index";
            RedirectingTimeout = 3000;
        }
    }
}