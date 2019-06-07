using ClothShopK.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothShopK.Web.ViewModel
{
    public class HomeViewModel
    {
        public List<Category> FeaturedCategories { get; set; }
        public List<Product> FeaturedProducts { get; set; }
    }
}