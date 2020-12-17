﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Domains
{
    public class Pedido : BaseDomain
    {
       
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

       
    }
}
