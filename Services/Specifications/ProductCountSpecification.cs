using Domain.Contracts;
using Domain.Entities;
using Shared.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductCountSpecification : Specification<Product>
    {
        public ProductCountSpecification(ProductSpecificationParams specs)
            : base(product => (!specs.BrandId.HasValue || product.BrandId == specs.BrandId) &&
                             (!specs.TypeId.HasValue || product.TypeId == specs.TypeId) &&
                             (string.IsNullOrWhiteSpace(specs.Search) || product.Name.ToLower().Contains(specs.Search.ToLower().Trim())))
        {
        }
    }
}
