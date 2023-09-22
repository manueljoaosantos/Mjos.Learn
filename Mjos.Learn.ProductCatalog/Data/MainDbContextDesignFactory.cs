namespace Mjos.Learn.ProductCatalog.Data;

public class MainDbContextDesignFactory : DbContextDesignFactoryBase<MainDbContext>
{
    public MainDbContextDesignFactory() : base("northwind_db")
    {
    }
}
