namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Web.ViewModels.Categories;
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using FastFood.Web.ViewModels.Orders;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(x => x.Name));

            //Employees
            CreateMap<RegisterEmployeeInputModel, Employee>();
            //.ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
            //.ForMember(x => x.Age, y => y.MapFrom(x => x.Age))
            //.ForMember(x => x.Address, y => y.MapFrom(x => x.Address))
            //.ForMember(x => x.PositionId, y => y.MapFrom(x => x.PositionId));
            //.ForMember(x => x.Position.Name, y => y.MapFrom(x => x.PositionName));

            CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(x => x.Position.Name));

            //Categories
            CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));
            CreateMap<Category, CategoryAllViewModel>();
            //.ForMember(x => x.Name, y => y.MapFrom(x => x.Name));
            CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.Name));

            //Items
            CreateMap<CreateItemInputModel, Item>();
            CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category.Name));

            CreateMap<Employee, CreateOrderViewModelEmployee>()
                .ForMember(x => x.Employee, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => x.Name));

            CreateMap<Item, CreateOrderViewModelItem>()
                .ForMember(x => x.Item, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ItemName, y => y.MapFrom(x => x.Name));

        }
    }
}
