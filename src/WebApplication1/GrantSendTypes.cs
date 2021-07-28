using System;

namespace WebApplication1
{
    [Flags]
    public enum GrantSendTypes
    {
        None = 0,
        Mail = 1,
        Sms = 2,
    }
}
