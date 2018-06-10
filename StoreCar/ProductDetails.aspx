<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductDetails.aspx.cs" Inherits="StoreCar.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="StoreCar.Models.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
      
        <ItemTemplate> 
         <br />
         <div class="row">
         <div class="thumbnail">
                         <img src="/Catalog/Images/<%#:Item.ImagePath %>" class="thumbnail" alt="<%#:Item.ProductName %>"/>
                         <div class="caption">
                         <h3><%#:Item.ProductName %></h3>
                         <ul class="list-group">
                         <li class="list-group-item"><span class="label label-default">Opis:</span> <%#:Item.Description %></li>
                         <li class="list-group-item"><span class="label label-default">Cena:&nbsp;</span> <%#: String.Format("{0:c}", Item.UnitPrice) %></li>
                         <li class="list-group-item"><span class="label label-default">Numer produktu:&nbsp;</span> <%#:Item.ProductID %></li>
                        </ul></div></div>
                        </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>