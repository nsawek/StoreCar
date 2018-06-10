<%@ Page Title="Samochody" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductList.aspx.cs" Inherits="StoreCar.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
           <AnonymousTemplate>
            <div class="jumbotron">
        <h1>Witaj w Store Car!</h1>
        <p>Najlepsze doświadczenia zakupowe, tylko u nas.</p>
        <p><a class="btn btn-primary btn-lg" href="/Account/Register" role="button">Dołącz już dziś!</a></p></div></AnonymousTemplate>
            <asp:ListView ID="productList" runat="server" 
                DataKeyNames="ProductID" GroupItemCount="4"
                ItemType="StoreCar.Models.Product" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table runat="server">
                        <tr>
                            <td>Nic nie znaleziono.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td runat="server" />
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <div class="col-sm-6 col-md-4">  <div class="thumbnail">
                    <div runat="server">
                    
                                    <a href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                        <img class="thumbnail" src="/Catalog/Images/Thumbs/<%#:Item.ImagePath%>"
                                             /></a>
                             <div class="caption">
                                 <span>
                                        <b>Cena: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                    </span>
                                   <p>
                                    <a class="btn btn-default" role="button" href="ProductDetails.aspx?productID=<%#:Item.ProductID%>">
                                        <%#:Item.ProductName%>
                                    </a>
                                    <a class="btn btn-primary" href="/AddToCart.aspx?productID=<%#:Item.ProductID %>">               
                                        <span class="ProductListItem">
                                               <i class="fas fa-cart-plus"></i> <b>Dodaj do koszyka<b>
                                        </span>          
                                    </a></p>
                          
                    </div></div></div></div>
                </ItemTemplate>
                <LayoutTemplate>
                    <table runat="server" style="width:100%;">
                        <tbody>
                            <tr runat="server">
                                <td runat="server">
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder" runat="server"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr runat="server">
                                <td runat="server"></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>