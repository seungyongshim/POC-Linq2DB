namespace WebApplication1.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using DataModels;
    using LinqToDB;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Route("[controller]")]
    [ApiController]
    public class IpInfosController : ControllerBase, IDisposable
    {
        private bool disposedValue;

        public IpInfosController(AUMSDB conn,
                                 ILogger<IpInfosController> logger)
        {
            Conn = conn;
            Logger = logger;

            Logger.LogInformation("Create IpInfoController");
        }

        public AUMSDB Conn { get; }
        public ILogger<IpInfosController> Logger { get; }

        [HttpPut]
        public async Task<int> Create(IpInfoDto ipInfoDto)
        {
            var id = await Conn.InsertWithInt32IdentityAsync(new IpInfo
            {
                IpAddress = ipInfoDto.IpAddress,
                GrantSend = (short)ipInfoDto.GrantSendType,
                UserInfoId = ipInfoDto.UserInfoId,
            });

            return id;
        }

        [HttpGet("{grantSend}")]
        public async Task<IActionResult> GetAll(short grantSend)
        {
            var q = from i in Conn.IpInfos
                    where grantSend != 0
                    where (i.GrantSend & grantSend) == grantSend
                    select new
                    {
                        i.IpInfoId,
                        i.IpAddress,
                        i.GrantSend,
                        GrantSendTypes = ((GrantSendTypes)i.GrantSend).ToString()
                    };
            return Ok(q.ToArray());
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var q = from i in Conn.IpInfos
                    join u in Conn.UserInfos on i.UserInfoId equals u.UserInfoId
                    select new
                    {
                        i.IpInfoId,
                        i.IpAddress,
                        i.GrantSend,
                        GrantSendTypes = ((GrantSendTypes)i.GrantSend).ToString(),
                        u.EmpNo,
                        u.CmpCode
                    };

            return Ok(await q.ToListAsync());
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Conn.Dispose();
                    Logger.LogInformation("Disposed IpInfoController");
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
