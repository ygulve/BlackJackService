using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackService.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using BlackJackService.Model;
using System.Net.Http;
using System.Net;
using BlackJackService.Data;

namespace BlackJackService.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class TransactionController : ControllerBase
    {

        private readonly ITransaction _repo;

        public TransactionController(ITransaction transaction)
        {
            _repo = transaction;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] List<Transaction> lstTrans)
        {
            try
            {
                return await _repo.IAddBulkInsert(lstTrans);
            }
            catch (Exception ex)
            {
                //Log this exception into file or into database
                throw new BlackJackException(ex.ToString());
            }            
        }
    }
}