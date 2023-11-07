﻿using System;
using System.Collections.Generic;

namespace Столовые_приборы.DB;

public partial class Order
{
    public int OrderId { get; set; }

    public int OrderStatusId { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int OrderPickupPointId { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderCode { get; set; }

    public int? UserId { get; set; }

    public virtual PickupPoint OrderPickupPoint { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;

    public virtual User? User { get; set; }
}
