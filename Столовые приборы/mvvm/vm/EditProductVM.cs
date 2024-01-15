using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Столовые_приборы.DB;
using Столовые_приборы.Pages;
using Столовые_приборы.Static;

namespace Столовые_приборы.mvvm.vm
{
    public class EditProductVM : BaseVM
    {
        public List<Category> Categories { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Unit> Units { get; set; }

        public Product SelectedProduct { get; }

        public VmCommand SelectImage { get; }
        public VmCommand PageBack { get; }
        public VmCommand SaveProduct { get; }
        

        public EditProductVM(Product selectedProduct)
        {
            PageBack = new VmCommand(() => {
                PageNavigator.CurrentPage = new ListProducts();
            }, ()=> true);
            Categories = Static.DataBase.Instance().Categories.ToList();
            Manufacturers = Static.DataBase.Instance().Manufacturers.ToList();
            Suppliers = Static.DataBase.Instance().Suppliers.ToList();
            Units = Static.DataBase.Instance().Units.ToList();

            if (selectedProduct == null)
                selectedProduct = new Product();
            SelectedProduct = selectedProduct;
            Signal(nameof(SelectedProduct));
        }

        
    }
}
