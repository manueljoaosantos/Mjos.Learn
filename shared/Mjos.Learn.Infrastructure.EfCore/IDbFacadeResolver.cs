using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Mjos.Learn.Infrastructure.EfCore
{
    public interface IDbFacadeResolver
    {
        DatabaseFacade Database { get; }
    }
}