using RsaProject.DbContexts;

namespace RsaProject.RepositoryService
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDbContext _applicationContext;
        private IBomRepository _bom;
        private IBomHeadRepository _bomHead;
        private IBomDetailRepository _bomDetail;


        public RepositoryWrapper(ApplicationDbContext applicationDbContext) {
            _applicationContext = applicationDbContext;
        }
        public IBomRepository Bom {
            get {
                if (_bom == null) {
                    _bom = new BomRepository(_applicationContext);
                }
                return _bom;
            }
        }

        public IBomHeadRepository BomHead {
            get
            {
                if (_bomHead == null)
                {
                    _bomHead = new BomHeadRepository(_applicationContext);
                }
                return _bomHead;
            }
        }

        public IBomDetailRepository BomDetail {
            get
            {
                if (_bomDetail == null)
                {
                    _bomDetail = new BomDetailRepository(_applicationContext);
                }
                return _bomDetail;
            }
        }

        public void save()
        {
            _applicationContext.SaveChanges();
        }
    }
}
