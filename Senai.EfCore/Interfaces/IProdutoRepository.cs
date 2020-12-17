using Senai.EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Interfaces
{
   public interface IProdutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid id);
        List<Produto> BuscarPorNome(String nome);
        void Adicionar(Produto produto);
        void Editar(Produto produto);
        void Remover(Guid Id);
    }
}
