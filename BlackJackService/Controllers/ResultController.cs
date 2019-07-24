using BlackJackService.Data;
using BlackJackService.Model;
using BlackJackService.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlackJackService.Controllers
{
    [Route("api/result")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class ResultController : ControllerBase
    {
        private readonly IResult _repo;

        public ResultController(IResult result)
        {
            _repo = result;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddResult([FromBody] List<Result> lstresult)
        {
            try
            {
                return await _repo.IAddResult(lstresult);
            }
            catch (Exception ex)
            {
                //Log this exception into file or into database
                throw new BlackJackException(ex.ToString());
            }
        }
    }
}
