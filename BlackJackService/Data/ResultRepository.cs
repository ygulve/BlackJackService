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
    public class ResultRepository : IResult
    {

        readonly BlackJackContext _blackJacksContext;

        public ResultRepository(BlackJackContext blackJackContext)
        {
            _blackJacksContext = blackJackContext;
        }

        public async Task<HttpResponseMessage> IAddResult(List<Result> lstresult)
        {
            try
            {
                await _blackJacksContext.result.AddRangeAsync(lstresult);
                await _blackJacksContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
