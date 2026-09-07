using _0_Framework.Application;

namespace ShopManagement.Application.Contract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long Id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
