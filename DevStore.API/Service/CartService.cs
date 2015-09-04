using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevStore.API.Models;

namespace DevStore.API.Service
{
    public static class CartService
    {
        public static void AddCartItem(CartItem item)
        {
            Cart cartShop = HttpContext.Current.Session["cart"] == null ? new Cart() : (Cart)HttpContext.Current.Session["cart"];
            cartShop.Itens.Add(item);
            cartShop.Total = cartShop.Itens.Sum(l => l.Developer.Price);
            HttpContext.Current.Session["cart"] = cartShop;
        }

        public static Cart GetCart()
        {
            return (Cart)HttpContext.Current.Session["cart"];
        }

        public static void RemoveCartItem(CartItem item)
        {

            if (HttpContext.Current.Session["cart"] != null)
            {
                Cart cartShop = (Cart)HttpContext.Current.Session["cart"];
                CartItem itemRemove = cartShop.Itens.FirstOrDefault(l => l.Developer.User == item.Developer.User);
                if (itemRemove != null)
                {
                    cartShop.Itens.Remove(itemRemove);
                    HttpContext.Current.Session["cart"] = cartShop;
                }

            }
        }
    }
}