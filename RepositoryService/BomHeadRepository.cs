using RsaProject.DbContexts;
using RsaProject.Model;

namespace RsaProject.RepositoryService
{
    public class BomHeadRepository:RepositoryBase<BomHead>,IBomHeadRepository
    {
        public BomHeadRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        { 
        }
    }
}
