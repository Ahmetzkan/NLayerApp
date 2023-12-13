﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Category : Entity<int>
    {
        //Id int olarak tutulur
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}