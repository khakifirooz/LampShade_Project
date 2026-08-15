namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        Domain.ProductCategoryAgg.ProductCategory GetDetails(long Id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
