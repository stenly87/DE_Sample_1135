using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Столовые_приборы.DB;

namespace Столовые_приборы.mvvm.vm
{
    internal class ListProductsVM : BaseVM
    {
        private string searchInfo;
        private List<Product> products;
        private string searchText = "";
        private Manufacturer selectedManufacturer;
        private string selectedSortValue;

        public List<string> SortValues { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }

        public Visibility AdminVisibility { get; set; }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                Search();
            }
        }

        public Manufacturer SelectedManufacturer
        {
            get => selectedManufacturer;
            set
            {
                selectedManufacturer = value;
                Search();
            }
        }
        public string SelectedSortValue
        {
            get => selectedSortValue;
            set
            {
                selectedSortValue = value;
                Search();
            }
        }

        public VmCommand CreateProduct { get; set; }
        public VmCommand EditProduct { get; set; }
        public VmCommand DeleteProduct { get; set; }

        public string SearchInfo
        {
            get => searchInfo;
            set
            {
                searchInfo = value;
                Signal();
            }
        }
        public List<Product> Products
        {
            get => products;
            set
            {
                products = value;
                Signal();
            }
        }
        public Product SelectedProduct { get; set; }

        public ListProductsVM()
        {
            AdminVisibility = Static.User.Logged.UserRole == 1 ? Visibility.Visible : Visibility.Collapsed;

            SortValues = new List<string>(new string[] { "По возрастанию", "По убыванию" });

            Manufacturers = Static.DataBase.Instance().Manufacturers.ToList();
            Manufacturers.Insert(0, new Manufacturer { Title = "Все производители" });
        }

        private void Search()
        {
            var db = Static.DataBase.Instance();

            var products = db.Products.
                Include(s => s.ProductManufacturer).
                Include(s => s.ProductCategory).
                Include(s => s.ProductSupplier).
                Include(s => s.ProductUnit);
            IQueryable<Product> filterProduct;
            if (SelectedManufacturer.ManufacturerId != 0)
                filterProduct = products.Where(s => s.ProductManufacturerId == SelectedManufacturer.ManufacturerId);
            else
                filterProduct = products;
            filterProduct = filterProduct.Where(s => s.ProductManufacturer.Title.Contains(searchText) ||
                s.ProductSupplier.Title.Contains(searchText) ||
                s.ProductArticleNumber.Contains(searchText) ||
                s.ProductDescription.Contains(searchText) ||
                s.ProductName.Contains(searchText)
                );
            if (SelectedSortValue == "По возрастанию")
               Products = filterProduct.OrderBy(s => s.ProductCost).ToList();
            else
                Products = filterProduct.OrderByDescending(s => s.ProductCost).ToList();

        }
    }
}
