﻿using System.Diagnostics;

namespace Mjos.Learn.Core.Helpers
{
    public static class GuidHelper
    {
        [DebuggerStepThrough]
        public static Guid NewGuid(string guid = null)
        {
            return string.IsNullOrWhiteSpace(guid) ? Guid.NewGuid() : new Guid(guid);
        }
    }
}
