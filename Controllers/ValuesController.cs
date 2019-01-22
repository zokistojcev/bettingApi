using System.Collections.Generic;
using System.Linq;
using BettingApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BettingApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly BettingContext _bettingContext;

        public ValuesController(BettingContext bettingContext)
        {
           _bettingContext = bettingContext;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Odds> Get()
        {

            var allOdds = _bettingContext.Odds.ToList();
            return allOdds;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
