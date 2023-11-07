using System;
using System.Collections.Generic;

namespace Столовые_приборы.DB;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public int ProductCategoryId { get; set; }

    public int ProductManufacturerId { get; set; }

    public decimal ProductCost { get; set; }

    public byte ProductDiscountAmount { get; set; }

    public int ProductQuantityInStock { get; set; }

    public int ProductUnitId { get; set; }

    public int ProductSupplierId { get; set; }

    public int ProductDiscountAmountMax { get; set; }

    public byte[]? ProductPhoto { get; set; }

    public string? ProductStatus { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Category ProductCategory { get; set; } = null!;

    public virtual Manufacturer ProductManufacturer { get; set; } = null!;

    public virtual Supplier ProductSupplier { get; set; } = null!;

    public virtual Unit ProductUnit { get; set; } = null!;
}
