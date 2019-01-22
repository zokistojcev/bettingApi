using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BettingApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Odds")]
    public class OddsController : Controller
    {

        private readonly BettingContext _bettingContext;

        public OddsController(BettingContext bettingContext)
        {
            _bettingContext = bettingContext;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Odds> Get()
        {

            
            return _bettingContext.Odds.ToList();
        }
    }


}