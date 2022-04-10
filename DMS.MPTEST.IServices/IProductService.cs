namespace DMS.MPTEST.IServices
{
    /// <summary>
    /// 产品接口
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<ProductEntityResult> GetProduct(long id);

    }
}
