﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Type { get; set; }

        public List<User> Users { get; set;}
    }
}
