using RsaProject.DbContexts;
using RsaProject.Model;

namespace RsaProject.RepositoryService
{
    public class BomRepository : RepositoryBase<Bom>, IBomRepository
    {
        public BomRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

    }
}
