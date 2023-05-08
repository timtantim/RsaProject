using Microsoft.EntityFrameworkCore;
using RsaProject.Model;

namespace RsaProject.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Bom> Bom { get; set; }

    }
}
