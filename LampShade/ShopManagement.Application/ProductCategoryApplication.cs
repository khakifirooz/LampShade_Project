using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operation = new OperationResult();

            if (_productCategoryRepository.Exists(command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            var slug = command.Slug.Slugifyy();
            var productCategory = new ProductCategory(command.Name, command.Description,
                command.Picture, command.PictureTitle, command.PictureAlt, command.Keyword,
                command.MetaDescription, slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SavaChanges();

            return operation.Succeeded();


        }

        public OperationResult Edit(EditProductCategory command)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetDetails(long Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
