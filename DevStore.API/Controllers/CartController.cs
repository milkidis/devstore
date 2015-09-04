using System;
using DevStore.Entity;
using DevStore.Service;
using DevStore.API.Service;
using DevStore.API.ModelPresenter;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using DevStore.API.Models;

namespace DevStore.API.Controllers
{
    public class CartController : ApiController
    {


        [HttpPost]
        public JsonMessage AddItem(Developer dev)
        {
            JsonMessage jsonReturn = new JsonMessage();
            try
            {

                CartService.AddCartItem(new CartItem() { Developer = dev });

                jsonReturn.Success = "OK";
            }
            catch (Exception e)
            {
                jsonReturn.Err = "Error " + e.Message;
            }


            return jsonReturn;

        }

        [HttpGet]
        public JsonMessage<Cart> GetAll()
        {
            JsonMessage<Cart> jsonReturn = new JsonMessage<Cart>();
            try
            {

                Cart cart = CartService.GetCart();
                jsonReturn.BusinessObject = cart;
                jsonReturn.Success = "OK";
            }
            catch (Exception e)
            {
                jsonReturn.Err = "Error " + e.Message;
            }

            return jsonReturn;
        }


        [HttpPost]
        public JsonMessage RemoveItem(Developer dev)
        {
            JsonMessage jsonReturn = new JsonMessage();
            try
            {

                CartService.RemoveCartItem(new CartItem() { Developer = dev });
                jsonReturn.Success = "OK";
            }
            catch (Exception e)
            {
                jsonReturn.Err = "Error " + e.Message;
            }
            return jsonReturn;

        }

        public JsonMessage<Cart> Purchase(string cupom)
        {
            JsonMessage<Cart> jsonReturn = new JsonMessage<Cart>();
            Cart cart = CartService.GetCart();
            if (cupom.ToUpper().Equals("SHIPIT"))
            {
                cart.Total = cart.Total - ((cart.Total * 10) / 100);
            }
            jsonReturn.BusinessObject = cart;
            return jsonReturn;
        }
    }
}
