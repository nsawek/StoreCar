﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using StoreCar.Logic;

namespace StoreCar
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("BŁĄD : Nie można odnaleść ID produktu.");
                throw new Exception("BŁĄD : Bez ID produktu nie możemy zakończyć.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}