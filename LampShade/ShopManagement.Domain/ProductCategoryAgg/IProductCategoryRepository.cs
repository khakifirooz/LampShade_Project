using System.Linq.Expressions;
using _0_Framework.Domain;
using ShopManagement.Application.Contract.ProductCategory;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IRepository<long , ProductCategory>
    {
        void SaveChanges();
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
