﻿using CoreMap.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class SupplierMap : CoreMap<Supplier>
    {
        public SupplierMap()
        {
            ToTable("dbo.Suppliers");
            Property(x => x.CompanyName).IsRequired().HasMaxLength(255);
            Property(x => x.Address).IsOptional().HasMaxLength(500);

        }
    }
}
