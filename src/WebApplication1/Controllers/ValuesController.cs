namespace WebApplication1.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using DataModels;
    using LinqToDB;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class IpInfoController : ControllerBase
    {
        public IpInfoController(AUMSDB conn)
        {
            this.Conn = conn;
        }

        public AUMSDB Conn { get; }

        [HttpPut]
        public async Task<int> Create(IpInfoDto ipInfoDto)
        {
            var id = await this.Conn.InsertWithInt32IdentityAsync(new IpInfo
            {
                IpAddress = ipInfoDto.IpAddress
            });

            foreach (var item in ipInfoDto.GrantSends)
            {
                await this.Conn.InsertAsync(new MNInfoGrantSend
                {
                    IpInfoId = id,
                    GrantSendId = item
                });
            }

            return id;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var s = (from g in Conn.GrantSends
                     from i in Conn.IpInfo
                     join m in Conn.MNInfoGrantSends
                         on new { g.GrantSendId, i.IpInfoId }
                         equals new { m.GrantSendId, m.IpInfoId }
                     select new
                     {
                         IpInfo = i,
                         GrantSend = g,
                     }).Distinct().AsEnumerable();
            var q = (from r in s
                     group r by r.IpInfo.IpInfoId into l
                     select new
                    {
                        Id = l.Key,
                        IpAddress = l.Select(x => x.IpInfo.IpAddress).First(),
                        GrantNames = from b in l
                                     select b.GrantSend
                    });
                     

            return Ok(q.ToArray());
        }

    }
}
