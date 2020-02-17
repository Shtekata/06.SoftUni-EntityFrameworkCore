namespace FastFood.Web.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;

    using Data;
    using ViewModels.Orders;
    using AutoMapper.QueryableExtensions;

    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var employees = context
                .Employees
                .ProjectTo<CreateOrderViewModelEmployee>(mapper.ConfigurationProvider)
                .ToList();

            var items = context
                .Items
                .ProjectTo<CreateOrderViewModelItem>(mapper.ConfigurationProvider)
                .ToList();

            var result = new CreateOrderViewModel
            {
                EmployeeModel = employees,
                ItemModel = items
            };

            return this.View(result);
    }

    [HttpPost]
    public IActionResult Create(CreateOrderInputModel model)
    {
        return this.RedirectToAction("All", "Orders");
    }

    public IActionResult All()
    {
        throw new NotImplementedException();
    }
}
}
