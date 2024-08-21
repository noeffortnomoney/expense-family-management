using System;

namespace EFM.Repository.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        EFMDbContext Init();
    }
}