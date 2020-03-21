using System.Collections.Generic;

namespace LibraryApp.WebApp.NotifyModels
{
    public class NotifyViewModelBase<T>
    {
        public List<T> Items { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public bool IsRedirecting { get; set; }
        public string RedirectingUrl { get; set; }
        public int RedirectingTimeout { get; set; }
        public string Color { get; set; }

        public NotifyViewModelBase()
        {
            Items = new List<T>();
            Header = "Yönlendiriliyorsunuz..";
            Title = "Geçersiz İşlem";
            IsRedirecting = true;
            RedirectingUrl = "/Home/Index";
            RedirectingTimeout = 1500;
            Color = "success";
        }
    }
}