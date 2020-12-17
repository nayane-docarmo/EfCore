using System.ComponentModel.DataAnnotations;

namespace Senai.EfCore.Domains
{
    public class Produto : BaseDomain
    {
        /// <summary>
        /// Define a classe produto
        /// </summary>

        public string Nome { get; set; }
        public float Preco { get; set; }
    }
}
