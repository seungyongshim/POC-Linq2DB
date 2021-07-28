using System;

namespace WebApplication1
{
    [Flags]
    public enum GrantSendTypes : short
    {
        None = 0,
        Mail = 1,
        Sms = 2,
        BackOffice = 8//16384
    }
}
