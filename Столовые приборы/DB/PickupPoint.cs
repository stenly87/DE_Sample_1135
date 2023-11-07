using System;
using System.Collections.Generic;

namespace Столовые_приборы.DB;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public int PointIndex { get; set; }

    public string PointTown { get; set; } = null!;

    public string PointStreet { get; set; } = null!;

    public string? PointHouse { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
