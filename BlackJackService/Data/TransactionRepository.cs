using BlackJackService.Context;
using BlackJackService.Model;
using BlackJackService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlackJackService.Data
{
    public class TransactionRepository : ITransaction
    {

        readonly BlackJackContext _blackJacksContext;

        public TransactionRepository(BlackJackContext blackJackContext)
        {
            _blackJacksContext = blackJackContext;
        }
        public async Task<HttpResponseMessage> IAddBulkInsert(List<Transaction> lstTransactions)
        {
            try {
                
               await _blackJacksContext.transaction.AddRangeAsync(lstTransactions);
               await _blackJacksContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //thorw exception
                //Log into database
                throw ex;
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
