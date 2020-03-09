namespace LibraryApp.DataAccessLayer.EntityFramework
{
    // singleton patter
    public class RepositoryBase
    {
        protected static DatabaseContext _db;

        private static object _lock = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        public static DatabaseContext CreateContext()
        {
            if (_db == null)
            {
                lock (_lock)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContext();
                    }
                }
            }

            return _db;
        }
    }
}