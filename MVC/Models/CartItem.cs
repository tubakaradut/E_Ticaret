using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }
        public Guid Id { get; set; }
        public string ProductName  { get; set; }
        public int Quantity  { get; set; }
        public decimal? Price  { get; set; }
        public decimal? SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}