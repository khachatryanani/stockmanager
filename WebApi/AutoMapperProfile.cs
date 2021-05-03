using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess;
using WebApi.Models;

namespace WebApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Worker, WorkerDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>()
                              .ForMember(dest => dest.CustomerId,
                                         opt => opt.MapFrom(src => src.Customer.CustomerId))
                              .ForMember(dest => dest.CustomerName,
                                         opt => opt.MapFrom(src => src.Customer.Name))
                              .ForMember(dest => dest.Receiver,
                                         opt =>  opt.MapFrom(src => src.Receiver.ToString()))
                              .ForMember(dest => dest.ReceiverId,
                                         opt => opt.MapFrom(src => src.Receiver.WorkerId))
                              .ForMember(dest => dest.Deliverer,
                                         opt => opt.MapFrom(src => src.Deliverer.ToString()))
                              .ForMember(dest => dest.DelivererId,
                                         opt => opt.MapFrom(src => src.Deliverer.WorkerId));
            CreateMap<Stock, StockDTO>()
                              .ForMember(dest => dest.ProductId,
                                         opt => opt.MapFrom(src => src.StockedProduct.ProductId))
                              .ForMember(dest => dest.ProductName,
                                         opt => opt.MapFrom(src => src.StockedProduct.Name))
                              .ForMember(dest => dest.ProductType,
                                         opt => opt.MapFrom(src => src.StockedProduct.Type))
                              .ForMember(dest => dest.Unit,
                                         opt => opt.MapFrom(src => src.StockedProduct.Unit))
                              .ForMember(dest => dest.UnitPrice,
                                         opt => opt.MapFrom(src => src.StockedProduct.Price));
            CreateMap<StockItem, StockItemDTO>()
                               .ForMember(dest => dest.ProductId,
                                         opt => opt.MapFrom(src => src.StockedProduct.ProductId))
                              .ForMember(dest => dest.ProductName,
                                         opt => opt.MapFrom(src => src.StockedProduct.Name))
                              .ForMember(dest => dest.ProductType,
                                         opt => opt.MapFrom(src => src.StockedProduct.Type))
                              .ForMember(dest => dest.Unit,
                                         opt => opt.MapFrom(src => src.StockedProduct.Unit))
                              .ForMember(dest => dest.UnitPrice,
                                         opt => opt.MapFrom(src => src.StockedProduct.Price))
                              .ForMember(dest => dest.CreatedById,
                                         opt => opt.MapFrom(src => src.Worker.WorkerId))
                              .ForMember(dest => dest.CreatedBy,
                                         opt => opt.MapFrom(src => src.Worker.ToString()));
            CreateMap<OrderItem, OrderItemDTO>()
                              .ForMember(dest => dest.ProductName,
                                         opt => opt.MapFrom(src => src.OrderedProduct.Name))
                              .ForMember(dest => dest.UnitPrice,
                                         opt => opt.MapFrom(src => src.OrderedProduct.Price))
                              .ForMember(dest => dest.Unit,
                                         opt => opt.MapFrom(src => src.OrderedProduct.Unit));
            CreateMap<ProductDTO, Product>();
            CreateMap<WorkerDTO, Worker>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<StockItemDTO, StockItem>()
                              .ForMember(dest => dest.ProductionDate,
                                         opt => opt.MapFrom(src => Convert.ToDateTime(src.ProductionDate)))
                              .ForMember(dest => dest.StockedDate,
                                         opt => opt.MapFrom(src => Convert.ToDateTime(src.StockedDate)))
                               .ForMember(dest => dest.StockedProduct.ProductId,
                                         opt => opt.MapFrom(src => src.ProductId))
                              .ForMember(dest => dest.StockedProduct.Name,
                                         opt => opt.MapFrom(src => src.ProductName))
                              .ForMember(dest => dest.StockedProduct.Type,
                                         opt => opt.MapFrom(src => src.ProductType))
                              .ForMember(dest => dest.StockedProduct.Unit,
                                         opt => opt.MapFrom(src => src.Unit))
                              .ForMember(dest => dest.StockedProduct.Price,
                                         opt => opt.MapFrom(src => src.UnitPrice));
            CreateMap<OrderDTO, Order>()
                             .ForMember(dest => dest.ReceivedDate,
                                        opt => opt.MapFrom(src => Convert.ToDateTime(src.ReceivedDate)))
                              .ForMember(dest => dest.Customer.CustomerId,
                                         opt => opt.MapFrom(src => src.CustomerId))
                              .ForMember(dest => dest.Customer.Name,
                                         opt => opt.MapFrom(src => src.CustomerName))
                              .ForMember(dest => dest.Receiver.WorkerId,
                                         opt => opt.MapFrom(src => src.ReceiverId))
                              .ForMember(dest => dest.Deliverer.WorkerId,
                                         opt => opt.MapFrom(src => src.DelivererId));
        }
    }
}
