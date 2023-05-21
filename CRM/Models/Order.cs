using System;

namespace CRM.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime Date { get; set; }

        public Company BuyingCompany { get; set; }
        public Company SellingCompany { get; set; }


    }

    public enum OrderStatus
    {
        Active = 1,
        Inactive = 2,
        Completed = 3,
    }
}
