using AutoMapper;
using Database.Entities;
using Models.MainModels;

namespace ShopWPF.Utils.MapperProfiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Employee, EmployeeModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Patronymic, opt => opt.MapFrom(s => s.Patronymic))
                .ForMember(_ => _.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth))
                .ForMember(_ => _.Gender, opt => opt.MapFrom(s => s.Gender))
                .ForMember(_ => _.SubdivisionId, opt => opt.MapFrom(s => s.SubdivisionId));
            CreateMap<EmployeeModel, Employee>()
                .ForMember(_ => _.Id, opt =>
                {
                    opt.Condition(s => s.Id != default);
                    opt.MapFrom(s => s.Id);
                })
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Patronymic, opt => opt.MapFrom(s => s.Patronymic))
                .ForMember(_ => _.DateOfBirth, opt => opt.MapFrom(s => s.DateOfBirth))
                .ForMember(_ => _.Gender, opt => opt.MapFrom(s => s.Gender))
                .ForMember(_ => _.SubdivisionId, opt => opt.MapFrom(s => s.SubdivisionId));

            CreateMap<Subdivision, SubdivisionModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(_ => _.ManagerId, opt => opt.MapFrom(s => s.ManagerId));
            CreateMap<SubdivisionModel, Subdivision>()
                .ForMember(_ => _.Id, opt =>
                {
                    opt.Condition(s => s.Id != default);
                    opt.MapFrom(s => s.Id);
                })
                .ForMember(_ => _.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(_ => _.ManagerId, opt => opt.MapFrom(s => s.ManagerId));

            CreateMap<Order, OrderModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.OrderNumber, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.CounterpartyName, opt => opt.MapFrom(s => s.CounterpartyName))
                .ForMember(_ => _.OrderNumber, opt => opt.MapFrom(s => s.OrderNumber))
                .ForMember(_ => _.OrderDate, opt => opt.MapFrom(s => s.OrderDate))
                .ForMember(_ => _.AuthorId, opt => opt.MapFrom(s => s.AuthorId));
            CreateMap<OrderModel, Order>()
                .ForMember(_ => _.Id, opt =>
                {
                    opt.Condition(s => s.Id != default);
                    opt.MapFrom(s => s.Id);
                })
                .ForMember(_ => _.CounterpartyName, opt => opt.MapFrom(s => s.CounterpartyName))
                .ForMember(_ => _.OrderNumber, opt => opt.MapFrom(s => s.OrderNumber))
                .ForMember(_ => _.OrderDate, opt => opt.MapFrom(s => s.OrderDate))
                .ForMember(_ => _.AuthorId, opt => opt.MapFrom(s => s.AuthorId));

            CreateMap<Product, ProductModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.ProductNumber, opt => opt.MapFrom(s => s.ProductNumber))
                .ForMember(_ => _.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(_ => _.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(_ => _.Count, opt => opt.MapFrom(s => s.Count))
                .ForMember(_ => _.OrderId, opt => opt.MapFrom(s => s.OrderId));
            CreateMap<ProductModel, Product>()
                .ForMember(_ => _.Id, opt =>
                {
                    opt.Condition(s => s.Id != default);
                    opt.MapFrom(s => s.Id);
                })
                .ForMember(_ => _.ProductNumber, opt => opt.MapFrom(s => s.ProductNumber))
                .ForMember(_ => _.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(_ => _.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(_ => _.Count, opt => opt.MapFrom(s => s.Count))
                .ForMember(_ => _.OrderId, opt => opt.MapFrom(s => s.OrderId));
        }
    }
}