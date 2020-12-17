using Senai.EfCore.Contexts;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai.EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        //instaciar pelo método construtor
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }


        #region Leitura
        /// <summary>
        /// Listar todos os Produtos
        /// </summary>
        /// <returns>Mostrar todos os produtos em forma de lista</returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produtos.ToList();
                //Esse método tem a função de listar tudo.

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca produtos pelo Id
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <returns>Retronar o Produto</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                // return _ctx.Produtos.FirstOrDefault(c => c.Id == id); /*Outro metodo*/
                //expressão lambda


                return _ctx.Produtos.Find(id); /*utilizado apenas para chaves primarias*/

                  
            }
            catch (Exception ex)   
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Busca produtos pelo nome
        /// </summary>
        /// <param name="nome">Nome do Produto</param>
        /// <returns>Retorna um produto</returns>

        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


        #region Gravação
        /// <summary>
        /// Adicionar um novo produto
        /// </summary>
        /// <param name="produto">Objeto do tipo Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adiciona objeto do tipo do produrto ao dbset do contexto 
                _ctx.Produtos.Add(produto);
                //_ctx.Set<Produto>().Add(produto);
                //_ctx.Entry(produto).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //Salvar as alterações no contexto
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Editar um produto
        /// </summary>
        /// <param name="produto">Produto a ser editado</param>
        public void Editar(Produto produto)
        {
            try
            {   //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //verificar se ele existe
                //Caso não existir gera uma exception
                if(produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Caso exista altera sua propriedade
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Alterar Produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salvar contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Remove um Produto
        /// </summary>
        /// <param name="Id">Id do Produto</param>
        public void Remover(Guid Id)
        {
            try
            {
                //Buscar produto pelo id
                Produto produtoTemp = BuscarPorId(Id);

                //verificar se ele existe
                //Caso não existir gera uma exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");
                
                //Remove o produto do dbSet
                _ctx.Produtos.Remove(produtoTemp);
                // Salva as alterações do contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #endregion


    }
}
