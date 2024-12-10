using Microsoft.EntityFrameworkCore.Storage;
using ZiekenFonds.API.Data.Repository;

namespace ZiekenFonds.API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZiekenFondsApiContext _context;
        private IActiviteitRepository _activiteitRepository;
        private IBestemmingRepository _bestemmingRepository;
        private IDeelnemerRepository _deelnemerRepository;
        private IFotoRepository _fotoRepository;
        private IGroepsReisRepository _groepsReisRepository;
        private IKindRepository _kindRepository;
        private IMonitorRepository _monitorRepository;
        private IOnkostenRepository _onkostenRepository;
        private IOpleidingRepository _opleidingRepository;
        private IReviewRepository _reviewRepository;

        public UnitOfWork(ZiekenFondsApiContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public IActiviteitRepository ActiviteitenRepository
        {
            get
            {
                return _activiteitRepository ??= new ActiviteitRepository(_context);
            }
        }

        public IBestemmingRepository BestemmingRepository
        {
            get
            {
                return _bestemmingRepository ??= new BestemmingRepository(_context);
            }
        }

        public IDeelnemerRepository DeelnemerRepository
        {
            get
            {
                return _deelnemerRepository ??= new DeelnemerRepository(_context);
            }
        }

        public IFotoRepository FotoRepository
        {
            get
            {
                return _fotoRepository ??= new FotoRepository(_context);
            }
        }

        public IGroepsReisRepository GroepsReisRepository
        {
            get
            {
                return _groepsReisRepository ??= new GroepsReisRepository(_context);
            }
        }

        public IKindRepository KindRepository
        {
            get
            {
                return _kindRepository ??= new KindRepository(_context);
            }
        }

        public IMonitorRepository MonitorRepository
        {
            get
            {
                return _monitorRepository ??= new MonitorRepository(_context);
            }
        }

        public IOnkostenRepository OnkostenRepository
        {
            get
            {
                return _onkostenRepository ??= new OnkostenRepository(_context);
            }
        }

        public IOpleidingRepository OpleidingRepository
        {
            get
            {
                return _opleidingRepository ??= new OpleidingRepository(_context);
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                return _reviewRepository ??= new ReviewRepository(_context);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}