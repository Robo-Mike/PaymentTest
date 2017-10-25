
namespace ClearBank.DeveloperTest.Data
{
    public class AccountAccountDataStoreFactory : IAccountDataStoreFactory
    {
        public IAccountDataStore Create(string dataStoreType)
        {
            if (dataStoreType == "Backup")
            {
                // Do something to change db used
                // Here I believe that the AccountDataStore and Backup are probably identical apart from the database connection
                // so we just need to create context with different connection string
                
            }
            return new AccountDataStore();
        }
    }
}
