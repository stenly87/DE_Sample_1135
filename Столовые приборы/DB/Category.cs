using System;
using System.Collections.Generic;

namespace Столовые_приборы.DB;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
