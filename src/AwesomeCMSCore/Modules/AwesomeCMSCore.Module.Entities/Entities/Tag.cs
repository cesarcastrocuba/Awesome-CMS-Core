﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeCMSCore.Module.Entities.Entities
{
    public class Tag: BaseEntity
    {
        public string TagName { get; set; }
        public TagGroup TagGroup { get; set; }
    }
}
