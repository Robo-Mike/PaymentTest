using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountDataStore
    {
        public AccountDataStore(string dataStoreType)
        {
            if (dataStoreType == "Backup")
            {
                // Do something to change db used
                // Here I believe that the AccountDataStore and Backup are probably identical apart from the database connection
                // so we just need to create context with different connection string
 
            }
        }

        public Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Account();
        }

        public void UpdateAccount(Account account)
        {
            // Update account in database, code removed for brevity
        }

        public void Commit()
        {
            //commit the unit of work, in this way we should be able to make the account check and update atomic
        }


    }
}
