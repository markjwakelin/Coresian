using System;
using Coresian.Interfaces.Providers;

namespace Coresian.Providers
{
    public class GuidProvider : IGuidProvider
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
