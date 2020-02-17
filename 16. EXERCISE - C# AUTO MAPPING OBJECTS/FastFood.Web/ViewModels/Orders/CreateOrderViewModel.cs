using System.Collections.Generic;

namespace FastFood.Web.ViewModels.Orders
{
    public class CreateOrderViewModel
    {
        public List<CreateOrderViewModelEmployee> EmployeeModel { get; set; }

        public List<CreateOrderViewModelItem> ItemModel { get; set; }
    }
}
