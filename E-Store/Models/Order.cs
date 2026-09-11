using System;
using System.Collections.Generic;

namespace E_Store.Models;

public partial class Order
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
