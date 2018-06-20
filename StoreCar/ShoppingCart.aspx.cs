using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StoreCar.Models;
using StoreCar.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace StoreCar
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                decimal allcoast = 0;
                allcoast = usersShoppingCart.GetTotal();
                if (allcoast > 0)
                {
                    lblTotal.Text = String.Format("{0:c}", allcoast);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "Twój koszyk jest pusty";
                    UpdateBtn.Visible = false;
                }
            }

        }
        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }
        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();
                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rV = new OrderedDictionary();
                    rV = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rV["ProductID"]);
                    CheckBox Usun = new CheckBox();
                    Usun = (CheckBox)CartList.Rows[i].FindControl("Usun");
                    cartUpdates[i].RemoveItem = Usun.Checked;
                    TextBox qtyTextBox = new TextBox();
                    qtyTextBox = (TextBox)CartList.Rows[i].FindControl("QTY");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt32(qtyTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }
        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values=new OrderedDictionary();
            foreach
            (DataControlFieldCell cell in row.Cells)
            {
            if (cell.Visible)
                {
                cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }
    }
}