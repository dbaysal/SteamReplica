﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Basket : BaseEntity
    {
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<Game>? Games { get; set; }
    }
}
