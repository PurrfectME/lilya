using System;
using System.Collections.Generic;

namespace CRM.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Company Client { get; set; }

        public int ClientId { get; set; }

        public List<OrderFile> Files { get; set; }
    }

    public class OrderFile
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Filename { get; set; }
        public byte[] File { get; set; }
        public Order Order { get; set; }
    }

    public enum OrderStatus
    {
        Accepted = 1,
        InProgress = 2,
        Completed = 3,
    }
}
