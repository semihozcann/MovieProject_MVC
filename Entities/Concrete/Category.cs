﻿using Shared.Entities.Abstract;
using Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
