﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Entities
{
    public class Achievement : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
