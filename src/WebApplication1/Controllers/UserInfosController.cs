// https://docs.microsoft.com/ko-kr/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio
namespace WebApplication1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DataModels;
    using LinqToDB;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    [ApiController]
    public class UserInfosController : Controller
    {
        public UserInfosController(AUMSDB conn) => Conn = conn;

        public AUMSDB Conn { get; }

        [HttpGet]
        public async Task<IEnumerable<UserInfo>> Get()
        {
            var q = from x in Conn.UserInfos
                    select x;
            return await q.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var q = from x in Conn.UserInfos
                    where x.UserInfoId == id
                    select x;

            return Ok(await q.FirstAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInfoDto dto)
        {
            var q = Conn.InsertWithInt32IdentityAsync(new UserInfo
            {
                EmpNo = dto.EmpNo,
                CmpCode = dto.CmpCode
            });

            return Ok(await q);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserInfoDto dto)
        {
             var q = Conn.UpdateAsync(new UserInfo
             {
                 EmpNo = dto.EmpNo,
                 CmpCode = dto.CmpCode
             });

            return Ok(await q);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var q = Conn.DeleteAsync(new UserInfo
            {
                UserInfoId = id
            });

            return Ok(await q);
        }

    }
}
