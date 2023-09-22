using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mjos.Learn.ProductCatalog.UseCases;

namespace Mjos.Learn.ProductCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="fileGuid"></param>
        /// <returns></returns>
        [HttpGet("/api/v1/products/{id}")]
        public async Task<IResult> GetProductId(Guid id, ISender sender)
        {
            return await sender.Send(new MutateProduct.GetQuery { Id = id });
        }
    }
}
