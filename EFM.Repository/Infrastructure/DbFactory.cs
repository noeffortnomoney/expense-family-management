using System.Data.Odbc;
using System;

namespace EFM.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EFMDbContext dbContext;

        public EFMDbContext Init()
        {
            return dbContext ?? (dbContext = new EFMDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}