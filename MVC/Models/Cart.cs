using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Cart
    {
        Dictionary<Guid, CartItem> _myCart = new Dictionary<Guid, CartItem>();
        public List<CartItem> mycart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }
        public void DeleteItem(Guid id)
        {
            if (_myCart.ContainsKey(id))
            {
                _myCart.Remove(id);
            }
        }
        public void AddItem(CartItem cartItem)
        {
            if (_myCart.ContainsKey(cartItem.Id))
            {
                _myCart[cartItem.Id].Quantity += cartItem.Quantity;
            }
            _myCart.Add(cartItem.Id, cartItem);
        }









    }

   

    
}