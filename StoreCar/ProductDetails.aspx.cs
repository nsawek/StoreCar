﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreCar.Models;
using System.Web.ModelBinding;

namespace StoreCar
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e){}
        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new StoreCar.Models.ProductContext();
            IQueryable<Product> item = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                item = item.Where(p => p.ProductID == productId);
            }
            else
            {
                item = null;
            }
            return item;
        }
    }
}