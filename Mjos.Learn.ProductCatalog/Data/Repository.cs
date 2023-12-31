namespace Mjos.Learn.ProductCatalog.Data;

public class Repository<TEntity> : RepositoryBase<MainDbContext, TEntity> where TEntity : EntityRootBase
{
    public Repository(MainDbContext dbContext) : base(dbContext)
    {
    }
}
