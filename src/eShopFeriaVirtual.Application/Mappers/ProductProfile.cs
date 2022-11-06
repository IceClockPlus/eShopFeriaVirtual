using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopFeriaVirtual.Domain.Entities.Products;
using eShopFeriaVirtual.Application.Features.Products.Commands.CreateProduct;
using eShopFeriaVirtual.Domain.DTO.Products;

namespace eShopFeriaVirtual.Application.Mappers
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            #region Queries
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(p => p.Price));
            #endregion

            #region Commands
            CreateMap<CreateProductRequest, Product>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(p => p.Price));
            #endregion
        }
    }
}
