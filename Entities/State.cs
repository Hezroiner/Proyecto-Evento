﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
