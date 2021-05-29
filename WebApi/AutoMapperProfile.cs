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
            //DataAccess Model to WebApi Model
            CreateMap<Product, ProductModel>();
            CreateMap<Worker, WorkerModel>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<Order, OrderModel>()
                              .ForPath(dest => dest.CustomerId,
                                         opt => opt.MapFrom(src => src.Customer.CustomerId))
                              .ForPath(dest => dest.CustomerName,
                                         opt => opt.MapFrom(src => src.Customer.Name))
                              .ForPath(dest => dest.TotalPrice,
                                         opt => opt.MapFrom(src => string.Format("{0:C}",src.TotalPrice)))
                              .ForPath(dest => dest.Receiver,
                                         opt => opt.MapFrom(src => src.Receiver.ToString()))
                              .ForPath(dest => dest.ReceiverId,
                                         opt => opt.MapFrom(src => src.Receiver.WorkerId))
                               .ForPath(dest => dest.ReceivedDate,
                                         opt => opt.MapFrom(src => src.ReceivedDate.ToShortDateString()))
                              .ForPath(dest => dest.Deliverer,
                                         opt => opt.MapFrom(src => src.Deliverer.ToString()))
                              .ForPath(dest => dest.DelivererId,
                                         opt => opt.MapFrom(src => src.Deliverer.WorkerId))
                               .ForPath(dest => dest.DeliveryDate,
                                         opt => opt.MapFrom(src => src.DeliveryDate == default(DateTime) ? string.Empty : src.DeliveryDate.ToShortDateString()));
            CreateMap<OrderItem, OrderItemModel>()
                             .ForPath(dest => dest.ProductName,
                                        opt => opt.MapFrom(src => src.OrderedProduct.Name))
                             .ForPath(dest => dest.Unit,
                                        opt => opt.MapFrom(src => src.OrderedProduct.Unit))
                             .ForPath(dest => dest.Quantity,
                                        opt => opt.MapFrom(src => src.Quantity))
                             .ForPath(dest => dest.UnitPrice,
                                        opt => opt.MapFrom(src => string.Format("{0:C}", src.OrderedProduct.Price)));
            CreateMap<Stock, StockModel>()
                              .ForPath(dest => dest.ProductId,
                                         opt => opt.MapFrom(src => src.StockedProduct.ProductId))
                              .ForPath(dest => dest.ProductName,
                                         opt => opt.MapFrom(src => src.StockedProduct.Name))
                              .ForPath(dest => dest.ProductType,
                                         opt => opt.MapFrom(src => src.StockedProduct.Type))
                              .ForPath(dest => dest.Unit,
                                         opt => opt.MapFrom(src => src.StockedProduct.Unit))
                              .ForPath(dest => dest.UnitPrice,
                                         opt => opt.MapFrom(src => string.Format("{0:C}",src.StockedProduct.Price)));
            CreateMap<StockItem, StockItemModel>()
                               .ForPath(dest => dest.ProductId,
                                         opt => opt.MapFrom(src => src.StockedProduct.ProductId))
                               .ForPath(dest => dest.ProductName,
                                         opt => opt.MapFrom(src => src.StockedProduct.Name))
                               .ForPath(dest => dest.ProductType,
                                         opt => opt.MapFrom(src => src.StockedProduct.Type))
                               .ForPath(dest => dest.ActualQuantity,
                                         opt => opt.MapFrom(src => src.Quantity))
                               .ForPath(dest => dest.Unit,
                                         opt => opt.MapFrom(src => src.StockedProduct.Unit))
                              .ForPath(dest => dest.UnitPrice,
                                         opt => opt.MapFrom(src => string.Format("{0:C}", src.StockedProduct.Price)))
                              .ForPath(dest => dest.StockedDate,
                                         opt => opt.MapFrom(src => src.StockedDate.ToShortDateString()))
                              .ForPath(dest => dest.ProductionDate,
                                         opt => opt.MapFrom(src => src.ProductionDate.ToShortDateString()))
                              .ForPath(dest => dest.ExpirationDate,
                                         opt => opt.MapFrom(src => src.ExpirationDate.ToShortDateString()))
                              .ForPath(dest => dest.CreatedBy,
                                         opt => opt.MapFrom(src => src.Worker.ToString()))
                              .ForPath(dest => dest.CreatedById,
                                         opt => opt.MapFrom(src => src.Worker.WorkerId));
            //WebApi Model to DataAccess Model
            CreateMap<ProductModel, Product>();
            CreateMap<WorkerModel, Worker>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<StockItemBaseModel, StockItem>()
                               .ForPath(dest => dest.StockedProduct.ProductId,
                                         opt => opt.MapFrom(src => src.ProductId))
                               .ForPath(dest => dest.StockedProduct.Price,
                                         opt => opt.MapFrom(src => src.UnitPrice))
                              .ForPath(dest => dest.Quantity,
                                         opt => opt.MapFrom(src => src.Quantity))
                              .ForPath(dest => dest.Worker.WorkerId,
                                         opt => opt.MapFrom(src => src.CreatedById))
                              .ForPath(dest => dest.ProductionDate,
                                         opt => opt.MapFrom(src => DateTime.Parse(src.ProductionDate)))
                              .ForPath(dest => dest.StockedDate,
                                         opt => opt.MapFrom(src => DateTime.Parse(src.StockedDate)));
            CreateMap<OrderItemBaseModel, OrderItem>()
                             .ForPath(dest => dest.OrderedProduct.ProductId,
                                        opt => opt.MapFrom(src => src.ProductId));
            CreateMap<OrderBaseModel, Order>()
                             .ForPath(dest => dest.Customer.CustomerId,
                                         opt => opt.MapFrom(src => src.CustomerId))
                             .ForPath(dest => dest.ReceivedDate,
                                        opt => opt.MapFrom(src => DateTime.Parse(src.ReceivedDate)))
                              .ForPath(dest => dest.Receiver.WorkerId,
                                         opt => opt.MapFrom(src => src.ReceiverId))
                              .ForPath(dest => dest.OrderItemList,
                                         opt => opt.MapFrom(src => src.OrderItems));
            CreateMap<OrderModel, Order>()
                .ForPath(dest => dest.Customer.CustomerId,
                                         opt => opt.MapFrom(src => src.CustomerId))
                            .ForPath(dest => dest.Customer.Name,
                                        opt => opt.MapFrom(src => src.CustomerName))
                            .ForPath(dest => dest.TotalPrice,
                                        opt => opt.Ignore())
                            .ForPath(dest => dest.ReceivedDate,
                                       opt => opt.MapFrom(src => DateTime.Parse(src.ReceivedDate)))
                             .ForPath(dest => dest.Receiver.WorkerId,
                                        opt => opt.MapFrom(src => src.ReceiverId))
                             .ForPath(dest => dest.DeliveryDate,
                                       opt => opt.MapFrom(src => src.DeliveryDate == string.Empty ? default(DateTime) : DateTime.Parse(src.DeliveryDate)))
                             .ForPath(dest => dest.Deliverer.WorkerId,
                                        opt => opt.MapFrom(src => src.DelivererId))
                              .ForPath(dest => dest.Status,
                                        opt => opt.MapFrom(src => src.Status));
        }
    }
}
