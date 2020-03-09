namespace LibraryApp.Entities.Messages
{
    public enum ErrorMessageCode
    {
        EmailAlreadyUsed = 100,
        UsernameAlreadyUsed = 101,
        EmailOrPassWrong = 200,
        UserNotFound = 201,
        NoBorrowsForUser = 800
    }
}