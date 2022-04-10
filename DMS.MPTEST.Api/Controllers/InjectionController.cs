using DMS.MPTEST.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DMS.MPTEST.Api.Controllers
{
    /// <summary>
    /// autofac
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionController : ControllerBase
    {
        /// <summary>
        /// 构造函数注入
        /// </summary>
        private readonly IProductService _productService;
        /// <summary>
        /// 构造函数注入
        /// </summary>

        public InjectionController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// 我是构造函数注入
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetProduct")]
        public async Task<ProductEntityResult> GetProduct(long id)
        {
            return await _productService.GetProduct(id);
        }
       
    }
}
