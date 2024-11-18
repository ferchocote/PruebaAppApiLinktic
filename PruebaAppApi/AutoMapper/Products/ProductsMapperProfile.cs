using AplicationServices.DTOs.Orders;
using AplicationServices.DTOs.Products;
using AutoMapper;
using PruebaAppApi.DataAccess.Entities;

namespace PruebaAppApi.AutoMapper.Products
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile()
        {
            FromProductToGetOrdersDto();
            FromAddProductDtoToProduct();
            FromUpdateProductDtoToProduct();
        }

        /// <summary>
        /// Convierte desde Product a GetProductsDto
        /// </summary>
        private void FromProductToGetOrdersDto()
        {
            CreateMap<Product, GetProductsDto>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.ID))
                .ForMember(target => target.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.Price, opt => opt.MapFrom(source => source.Price));
        }

        /// <summary>
        /// Convierte desde AddProductDto a Product
        /// </summary>
        private void FromAddProductDtoToProduct()
        {
            CreateMap<AddProductDto, Product>()
                .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.Price, opt => opt.MapFrom(source => source.Price))
                .ForMember(target => target.State, opt => opt.MapFrom(source => true));
        }

        /// <summary>
        /// Convierte desde UpdateProductDto a Product
        /// </summary>
        private void FromUpdateProductDtoToProduct()
        {
            CreateMap<UpdateProductDto, Product>()
                .ForMember(target => target.ID, opt => opt.MapFrom(source => source.ID))
                .ForMember(target => target.Name, opt => opt.MapFrom(source => source.Name))
                .ForMember(target => target.Description, opt => opt.MapFrom(source => source.Description))
                .ForMember(target => target.Price, opt => opt.MapFrom(source => source.Price))
                .ForMember(target => target.State, opt => opt.MapFrom(source => true));
        }
    }
}
