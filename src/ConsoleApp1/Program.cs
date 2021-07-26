using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Server=(Local);Database=AUMS;User Id=MT;Password=q1w2e3r4t5Y^U&I*O(P);Connection Timeout=3";

            using SqlConnection conn = new(connectionString);
            SqlServerCompiler compiler = new();
            using var db = new QueryFactory(conn, compiler);

            await conn.OpenAsync();


            //var i = await db.Query("SendGrant")
            //                .InsertAsync(new {
            //                    Name = "SMS"
            //                });

            var a = await db.Query("IpInfo")
                            .InsertAsync(new {
                                IpAddress = "127.0.0.1",
                                SendGrantId = new[] { 1, 2 }
                            });


            var q = await db.Query("IpInfo")
                            .GetAsync();

            var ret = q.ToList();

            await conn.CloseAsync();

        }
    }
}
