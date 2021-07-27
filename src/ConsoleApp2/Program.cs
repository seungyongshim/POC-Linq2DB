using System;
using System.Linq;
using DataModels;
using LinqToDB;
using LinqToDB.Configuration;

namespace ConsoleApp2
{
    internal class Program
    {
        //static string ConnectionString = "Server=(Local);Database=AUMS;User Id=MT;Password=q1w2e3r4t5Y^U&I*O(P);Connection Timeout=3";

        private static void Main(string[] args)
        {
            using (var db = new AUMSDB(new LinqToDbConnectionOptions(
                new LinqToDbConnectionOptionsBuilder().UseSqlServer(
                    "Server=(Local);Database=AUMS;User Id=MT;Password=q1w2e3r4t5Y^U&I*O(P);Connection Timeout=3"
                ))))
            {
                var q = from g in db.IpInfo
                        select g;

                foreach (var c in q)
                    Console.WriteLine($"{c.IpAddress}");

                Console.WriteLine();

                //var id = db.Insert(new IpInfo { IpAddress = "127.0.0.1" });

                //db.Insert(new MNInfoGrantSend { IpInfoId = id, GrantSendId = 1 });
                //db.Insert(new MNInfoGrantSend { IpInfoId = id, GrantSendId = 2 });

                var id1 = db.InsertWithInt32Identity(new IpInfo { IpAddress = "123.0.2.5" });

                db.Insert(new MNInfoGrantSend { IpInfoId = id1, GrantSendId = 1 });

                var s = from g in db.GrantSends
                        from i in db.IpInfo
                        join m in db.MNInfoGrantSends
                            on new { g.GrantSendId, i.IpInfoId }
                            equals new { m.GrantSendId, m.IpInfoId }
                        select new
                        {
                            g.Name,
                            i.IpAddress
                        };

                foreach (var item in s)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
