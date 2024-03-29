﻿using CoreMap.Map;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Map
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.SubCategoryName).IsRequired().HasMaxLength(255);
            Property(x => x.Description).IsOptional().HasMaxLength(255);
        }
    }
}
