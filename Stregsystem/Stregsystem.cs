using System;
using System.Collections.Generic;
using System.Transactions;
using src.Products;
using src.Shared;
using src.Users;
using Stregsystem.Shared;

namespace Stregsystem
{
    internal class Stregsystem 
    {
        // private IEnumerable<Product> ActiveProducts { get; set; } 
        
        private void BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        private void AddCreditToAccount(User user, DDK amount)
        {
            throw new NotImplementedException();
        }

        private void ExecuteTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Product> GetProductById(Id<Product> id)
        {
            throw new NotImplementedException();
        } 

        private IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        private User GetUserByUsername(Username username)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }
    }
    
}