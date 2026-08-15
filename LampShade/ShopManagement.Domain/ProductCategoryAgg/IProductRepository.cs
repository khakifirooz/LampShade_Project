namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductRepository
    {
        void Create(ProductCategory entity);
        ProductCategory Get(long id);
        List<ProductCategory> GetAll();
    }
}
