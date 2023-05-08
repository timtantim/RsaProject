namespace RsaProject.RepositoryService
{
    public interface IRepositoryWrapper
    {
        IBomRepository Bom { get; }
        IBomHeadRepository BomHead { get; }
        IBomDetailRepository BomDetail { get; }

        void save();
    }
}
