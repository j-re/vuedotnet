using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace vue.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Placed { get; set; } = DateTime.UtcNow;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Address DeliveryAddress { get; set; }
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
        public AppUser User { get; set; }
    }

    public class Address
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string TownCity { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string Postcode { get; set; }
    }
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ColourId { get; set; }
        public int StorageId { get; set; }
        public int Quantity { get; set; }
        public ProductVariant ProductVariant { get; set; }
    }

    public class OrderListViewModel
    {
        public int Id { get; set; }

        public string Customer { get; set; }
        public DateTime Placed { get; set; }
        public int Items { get; set; }
        public decimal Total { get; set; }
        public string PaymentStatus { get; set; }
    }

    public class CreateOrderViewModel
    {
        [Required]
        public string StripeToken { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string TownCity { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string Postcode { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
    }

    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public int ColourId { get; set; }
        public int StorageId { get; set; }
        public int Quantity { get; set; }
    }

    public class CreateOrderResponseViewModel
    {
        public int OrderId { get; set; }
        public string PaymentStatus { get; set; }
        public CreateOrderResponseViewModel(int orderId, PaymentStatus paymentStatus)
        {
            OrderId = orderId;
            PaymentStatus = paymentStatus.ToString();
        }
    }

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Declined
    }
}