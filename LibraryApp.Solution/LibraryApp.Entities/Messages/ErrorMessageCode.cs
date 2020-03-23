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
        BookCouldNotAdded = 1002,
        AddressCouldNotInserted = 1500,
        AddressCouldNotDeleted = 1501,
        NoAddressForUser = 1600,
        CategoryAlreadyExisted = 1700,
        CategoryNotFound = 1701,
        
    }
}