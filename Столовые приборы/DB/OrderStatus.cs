using System;
using System.Collections.Generic;

namespace Столовые_приборы.DB;

public partial class OrderStatus
{
    public int StatusId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
