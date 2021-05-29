using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DataAccess;
using FrontEnd_Desktop.MVVM.Model;

namespace FrontEnd_Desktop.Core
{
    public static class Mapper
    {
        public static AutoMapper.Mapper InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>()
                                .ForMember(dest => dest.Price,
                                             opt => opt.MapFrom(src => string.Format("{0:C}", src.Price)));
                cfg.CreateMap<Worker, WorkerDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<Stock, StockDTO>()
                                 .ForMember(dest => dest.StockItemList,
                                             opt => opt.Ignore());
                cfg.CreateMap<StockItem, StockItemDTO>();
                cfg.CreateMap<OrderItem, OrderItemDTO>();
                cfg.CreateMap<Order, OrderDTO>()
                                 .ForMember(dest => dest.Customer,
                                             opt => opt.MapFrom(src => src.Customer))
                                 .ForMember(dest => dest.ReceivedBy,
                                             opt => opt.MapFrom(src => src.Receiver))
                                 .ForMember(dest => dest.DeliveredBy,
                                             opt => opt.MapFrom(src => src.Deliverer))
                                 .ForMember(dest => dest.TotalPrice,
                                             opt => opt.MapFrom(src => string.Format("{0:C}", src.TotalPrice)))
                                 .ForMember(dest => dest.ReceivedDate,
                                             opt => opt.MapFrom(src => src.ReceivedDate.ToShortDateString()))
                                 .ForMember(dest => dest.DeliveryDate,
                                             opt => opt.MapFrom(src => src.DeliveryDate==default(DateTime) ? string.Empty : src.DeliveryDate.ToShortDateString()));

                cfg.CreateMap<ProductDTO, Product>()
                                 .ForMember(dest => dest.Price,
                                     opt => opt.MapFrom(src => Convert.ToDouble(src.Price)));
                cfg.CreateMap<WorkerDTO, Worker>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<StockItemDTO, StockItem>()
                                 .ForMember(dest => dest.ProductionDate,
                                        opt => opt.MapFrom(src => Convert.ToDateTime(src.ProductionDate)))
                                 .ForMember(dest => dest.StockedDate,
                                        opt => opt.MapFrom(src => Convert.ToDateTime(src.StockedDate)));
                cfg.CreateMap<OrderItemDTO, OrderItem>()
                                 .ForMember(dest => dest.OrderedProduct,
                                        opt => opt.MapFrom(src => src.OrderedProduct))
                                 .ForMember(dest => dest.Quantity,
                                        opt => opt.MapFrom(src => src.Quantity));
                cfg.CreateMap<OrderDTO, Order>()
                                 .ForMember(dest => dest.ReceivedDate,
                                            opt => opt.MapFrom(src => Convert.ToDateTime(src.ReceivedDate)))
                                 .ForMember(dest => dest.Receiver,
                                            opt => opt.MapFrom(src => src.ReceivedBy))
                                 .ForMember(dest => dest.Deliverer,
                                            opt => opt.MapFrom(src => src.DeliveredBy))
                                 .ForMember(dest => dest.OrderItemList,
                                            opt => opt.MapFrom(src => src.OrderItems))
                                 .ForMember(dest => dest.Customer,
                                            opt => opt.MapFrom(src => src.Customer))
                                 .ForPath(dest => dest.TotalPrice,
                                        opt => opt.Ignore());
            });

            return new AutoMapper.Mapper(config);
        }
    }
}