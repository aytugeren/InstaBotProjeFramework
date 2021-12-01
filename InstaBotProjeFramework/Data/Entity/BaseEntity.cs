﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaBotProjeFramework.Data.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}