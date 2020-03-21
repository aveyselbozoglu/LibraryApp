using LibraryApp.Entities.Messages;

namespace LibraryApp.WebApp.NotifyModels
{
    public class ErrorViewModel : NotifyViewModelBase<ErrorMessageObj>
    {
        public ErrorViewModel()
        {
            Color = "danger";
        }
    }
}