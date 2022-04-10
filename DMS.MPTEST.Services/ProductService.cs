using DMS.MPTEST.IServices;

namespace DMS.MPTEST.Services
{
    /// <summary>
    /// 产品服务
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductEntityResult> GetProduct(long id)
        {
            ProductEntityResult entity = new ProductEntityResult()
            {
                //long类型转为string输出
                Id = "1125964271981826048",
                ProductName = "aaaa",
                ProductPrice = 125.23m,
                CreatedTime = DateTime.Now,
            };
            return await Task.FromResult(entity);

        }

    }
}
