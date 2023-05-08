using RsaProject.DbContexts;
using RsaProject.Model;

namespace RsaProject.RepositoryService
{
    public class BomDetailRepository:RepositoryBase<BomDetail>,IBomDetailRepository
    {
        public BomDetailRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { 
        }
    }
}
