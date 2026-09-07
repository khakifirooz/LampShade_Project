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

            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");

            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name, command.Description,
                command.Picture, command.PictureTitle, command.PictureAlt, command.Keyword,
                command.MetaDescription, slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SavaChanges();

            return operation.Succeeded();


        }

        public OperationResult Edit(EditProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory != null)
                {
                if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                    return operationResult.Failed("امکان ثبت رکورد تکراری وجود ندارد");
                var slug = command.Slug.Slugify();
                productCategory.Edit(command.Name, command.Description, command.Picture, command.PictureTitle,
                    command.PictureAlt, command.Keyword, command.MetaDescription, slug);
                _productCategoryRepository.SavaChanges();
                return operationResult.Succeeded();
            }
            else
            {
                return operationResult.Failed("رکورد مورد نظر یافت نشد");
            }
        }

        public EditProductCategory GetDetails(long Id)
        {
            return _productCategoryRepository.GetDetails(Id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
