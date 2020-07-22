using EinTech.Test.Core;
using System;

namespace EinTech.Test.Services
{
    public class SystemInfo : ISystemInfo
    {
        public DateTime GetCurrentDateTime()
            => DateTime.UtcNow;
    }
}
