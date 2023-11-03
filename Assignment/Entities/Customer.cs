using System;
using System.Collections.Generic;

namespace Assignment.Entities;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    
}
