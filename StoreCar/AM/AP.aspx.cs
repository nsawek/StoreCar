using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreCar.Models;
using StoreCar.Logic;

namespace StoreCar.AM
{
    public partial class AP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Dodano produkt!";
            }

            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "Usunięto produkt!";
            }
        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            Boolean fOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fOK = true;
                    }
                }
            }

            if (fOK)
            {
                try
                {
                    // Zapis obraz
                    ProductImage.PostedFile.SaveAs(path + ProductImage.FileName);
                    // Zapis miniaturę obrazu.
                    ProductImage.PostedFile.SaveAs(path + "Thumbs/" + ProductImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                // Dodaj produkt do bazy danych DB.
                AddProducts products = new AddProducts();
                bool addSuccess = products.AddProduct(AddProductName.Text, AddProductDescription.Text,
                    AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);
                if (addSuccess)
                {
                    // Przeładuj stronę.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Nie udało się dodać produktu do bazy danych.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Zły fomat pliku z zdjeciem, użyj: .gif, .png, .jpeg, .jpg .";
            }
        }

        public IQueryable GetCategories()
        {
            var _db = new StoreCar.Models.ProductContext();
            IQueryable query = _db.Categories;
            return query;
        }

        public IQueryable GetProducts()
        {
            var _db = new StoreCar.Models.ProductContext();
            IQueryable query = _db.Products;
            return query;
        }

        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var _db = new StoreCar.Models.ProductContext())
            {
                int productId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                var myItem = (from c in _db.Products where c.ProductID == productId select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Products.Remove(myItem);
                    _db.SaveChanges();

                    // Przeładuj stronę.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Nie można usunąć produktu..";
                }
            }
        }
    }
}