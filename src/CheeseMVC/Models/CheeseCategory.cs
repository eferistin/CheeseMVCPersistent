﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseCategory
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public IList<Cheese> Cheeses { get; set; }  //represent the list of all items in a given category
    }
}
