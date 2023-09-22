using System.Linq.Expressions;

namespace Mjos.Learn.Core.Specification
{
    public class NoOpSpec<TEntity> : SpecificationBase<TEntity>
    {
        public override Expression<Func<TEntity, bool>> Criteria => p => true;
    }
}
