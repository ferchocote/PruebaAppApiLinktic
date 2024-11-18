using AplicationServices.DTOs.Orders;
using PruebaAppApi.DataAccess.Entities;
using AutoMapper;

namespace PruebaAppApi.AutoMapper.Orders
{
    public class OrdersMapperProfile : Profile
    {
        public OrdersMapperProfile()
        {
            FromOrderToGetOrdersDto();
            FromCreateOrderDtoToOrder();
            FromOrderItemDtoToOrderItem();
        }

        /// <summary>
        /// Convierte desde Order a GetOrdersDto
        /// </summary>
        private void FromOrderToGetOrdersDto()
        {
            CreateMap<Order, GetOrdersDto>()
                .ForMember(target => target.Id, opt => opt.MapFrom(source => source.ID))
                .ForMember(target => target.OrderDate, opt => opt.MapFrom(source => source.OrderDate))
                .ForMember(target => target.Number, opt => opt.MapFrom(source => source.Number))
                .ForMember(target => target.User, opt => opt.MapFrom(source => string.Concat(source.UserNavigation.FirstName, " ",source.UserNavigation.LastName)));
        }

        /// <summary>
        /// Convierte desde CreateOrderDto a CreateOrderDto
        /// </summary>
        private void FromCreateOrderDtoToOrder()
        {
            CreateMap<CreateOrderDto, Order>()
                .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.OrderDate, opt => opt.MapFrom(source => source.OrderDate))
                .ForMember(target => target.Number, opt => opt.MapFrom(source => source.Number))
                .ForMember(target => target.User, opt => opt.MapFrom(source => source.User));
        }

        /// <summary>
        /// Convierte desde OrderItemDto a OrderItem
        /// </summary>
        private void FromOrderItemDtoToOrderItem()
        {
            CreateMap<OrderItemDto, OrderItem>()
                .ForMember(target => target.ID, opt => opt.MapFrom(source => Guid.NewGuid()))
                .ForMember(target => target.Product, opt => opt.MapFrom(source => source.Product))
                .ForMember(target => target.Quantity, opt => opt.MapFrom(source => source.Quantity));
        }
    }
}
