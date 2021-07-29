namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class GrantSendTypesController : Controller
    {
        public record IndexResult(GrantSendTypes Enum, string EnumName);

        [HttpGet]
        public IEnumerable<IndexResult> Index()
        {
            var q = from x in Enum.GetValues<GrantSendTypes>()
                    where x != 0
                    let a = (int)x
                    select a;


            

            return q.DifferentCombinations(3).SelectMany(x => x)
                    .Append(0)
                                 .OrderBy(x => x)
                                 .Distinct()
                                 .Select(x => (GrantSendTypes)x)
                                 .Select(x => new IndexResult(x, x.ToString()));
        }

       
    }
}
