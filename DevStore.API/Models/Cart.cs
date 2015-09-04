using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevStore.API.Models
{
    public class Cart
    {
        public List<CartItem> Itens { get; set; }
        public decimal Total { get; set; }
    }
}