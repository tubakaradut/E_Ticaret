﻿using CoreMap.EntityCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
   public class Supplier: EntityRepository
    {
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
