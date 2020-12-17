﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Domains
{
    public abstract class BaseDomain
    {
        [Key]
        public Guid Id { get; set; }
        public BaseDomain()
        {
            Id = Guid.NewGuid();
        }
    }
}
