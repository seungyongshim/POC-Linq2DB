using System.Collections.Generic;

namespace WebApplication1
{
    public record IpInfoDto(string IpAddress, IList<int> GrantSends);
}
