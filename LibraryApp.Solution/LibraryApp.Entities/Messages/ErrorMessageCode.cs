namespace LibraryApp.Entities.Messages
{
    public enum ErrorMessageCode
    {
        EmailAlreadyUsed = 100,
        UsernameAlreadyUsed = 101,
        EmailOrPassWrong = 200,
        UserNotFound = 201,
        UserCouldNotEdited = 251,
        NoBorrowsForUser = 800,
        CouldNotBorrowed = 1000,
        BookNotFound = 1001,
        AddressCouldNotInserted = 1500,
        AddressCouldNotDeleted = 1501,
        NoAddressForUser = 1600
    }
}