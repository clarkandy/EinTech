using EinTech.Test.Core;
using System;

namespace Eintech.Test.Infrastructure
{
    public class SystemInfo : ISystemInfo
    {
        public DateTime GetCurrentDateTime()
            => DateTime.UtcNow;
    }
}
