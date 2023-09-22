using System.Linq.Expressions;

namespace Mjos.Learn.ProductCatalog.Domain.Specs;

public class GetCategoriesSpec : SpecificationBase<Category>
{
    public override Expression<Func<Category, bool>> Criteria => p => true;
}
