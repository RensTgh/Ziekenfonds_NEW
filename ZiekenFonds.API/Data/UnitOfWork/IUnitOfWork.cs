using Microsoft.EntityFrameworkCore.Storage;
using ZiekenFonds.API.Data.Repository;

namespace ZiekenFonds.API.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IActiviteitRepository ActiviteitenRepository { get; }
        IBestemmingRepository BestemmingRepository { get; }
        IDeelnemerRepository DeelnemerRepository { get; }
        IFotoRepository FotoRepository { get; }
        IGroepsReisRepository GroepsReisRepository { get; }
        IKindRepository KindRepository { get; }
        IMonitorRepository MonitorRepository { get; }
        IOnkostenRepository OnkostenRepository { get; }
        IOpleidingRepository OpleidingRepository { get; }
        IReviewRepository ReviewRepository { get; }

        IDbContextTransaction BeginTransaction();

        public Task SaveChangesAsync();
    }
}