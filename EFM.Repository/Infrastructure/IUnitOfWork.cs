namespace EFM.Repository.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}