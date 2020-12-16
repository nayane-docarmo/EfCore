using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Domains
{
    public class Produto
    {
        /// <summary>
        /// Define a classe produto
        /// </summary>

        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }


        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}
