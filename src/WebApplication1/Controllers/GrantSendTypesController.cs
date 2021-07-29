namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class GrantSendTypesController : Controller
    {
        public record IndexResult(GrantSendTypes Enum, string EnumName);

        [HttpGet]
        public IActionResult Index()
        {
            var q = (from x in Enum.GetValues<GrantSendTypes>()
                     where x != 0
                     let a = (int)x
                     select a).Memoize();

            var r = from m in Enumerable.Range(1, q.Count())
                    from x in q.DifferentCombinations(m)
                    select x;

            return Ok(r.Select(x => x.Sum())
                       .Append(0)
                       .OrderBy(x => x)
                       .Select(x => (GrantSendTypes)x)
                       .Select(x => new
                        {
                            TypeId = x,
                            TypeString = x.ToString()
                        }));
        }
    }
}
