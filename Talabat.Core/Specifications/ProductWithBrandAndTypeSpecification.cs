using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
    {
        // This Ctor is Used For Get All Products
        public ProductWithBrandAndTypeSpecification(ProductSpecParams specParams)
            :base(P => 
                (string.IsNullOrEmpty(specParams.Search) || P.Name.ToLower().Contains(specParams.Search))&& 
                (!specParams.BrandId.HasValue || P.ProductBrandId == specParams.BrandId.Value) &&
                (!specParams.TypeId.HasValue || P.ProductTypeId == specParams.TypeId.Value)
            )
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
            AddOrderBy(P => P.Name);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch(specParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(P => P.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(P => P.Price);
                        break;
                    default: 
                        AddOrderBy(P => P.Name);
                        break;
                }
            }

            ApplyPagination(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        }

        // This Ctor is Used For Get Product By Id
        public ProductWithBrandAndTypeSpecification(int id) : base(P => P.Id == id)
        {
            Includes.Add(P => P.ProductBrand);
            Includes.Add(P => P.ProductType);
        }

    }
}
