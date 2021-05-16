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
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Worker, WorkerDTO>();
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<Order, OrderDTO>();

                cfg.CreateMap<Stock, StockDTO>()
                                  .ForMember(dest => dest.StockItemList,
                                             opt => opt.Ignore());
                cfg.CreateMap<StockItem, StockItemDTO>();
                cfg.CreateMap<Order, OrderDTO>()
                                    .ForMember(dest => dest.CustomerId,
                                             opt => opt.MapFrom(src => src.Customer.CustomerId))
                                    .ForMember(dest => dest.CustomerName,
                                             opt => opt.MapFrom(src => src.Customer.Name))
                                    .ForMember(dest => dest.Receiver,
                                             opt => opt.MapFrom(src => src.Receiver.ToString()))
                                    .ForMember(dest => dest.ReceiverId,
                                             opt => opt.MapFrom(src => src.Receiver.WorkerId))
                                    .ForMember(dest => dest.Deliverer,
                                             opt => opt.MapFrom(src => src.Deliverer.ToString()))
                                    .ForMember(dest => dest.DelivererId,
                                             opt => opt.MapFrom(src => src.Deliverer.WorkerId))
                                    .ForMember(dest => dest.TotalPrice,
                                             opt => opt.MapFrom(src => String.Format("{0:C}",src.TotalPrice)))
                                     .ForMember(dest => dest.ReceivedDate,
                                             opt => opt.MapFrom(src => src.ReceivedDate.ToShortDateString()))
                                     .ForMember(dest => dest.DeliveryDate,
                                             opt => opt.MapFrom(src => src.DeliveryDate==default(DateTime) ? string.Empty : src.DeliveryDate.ToShortDateString()));

                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<WorkerDTO, Worker>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<StockItemDTO, StockItem>()
                             .ForMember(dest => dest.ProductionDate,
                                        opt => opt.MapFrom(src => Convert.ToDateTime(src.ProductionDate)))
                             .ForMember(dest => dest.StockedDate,
                                        opt => opt.MapFrom(src => Convert.ToDateTime(src.StockedDate)));
                cfg.CreateMap<OrderDTO, Order>()
                                 .ForMember(dest => dest.ReceivedDate,
                                            opt => opt.MapFrom(src => Convert.ToDateTime(src.ReceivedDate)));
            });

            return new AutoMapper.Mapper(config);
        }
    }
}
