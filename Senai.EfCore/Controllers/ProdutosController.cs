using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.EfCore.Domains;
using Senai.EfCore.Interfaces;
using Senai.EfCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os produtos do repositorio 
                var produto = _produtoRepository.Listar();

                //Verificar se esciste produtos,caso não exista retorna
                //Nocontent - sem conteudo
                if (produto.Count == 0)
                    return NoContent();

                //Caso exista retorna Ok e os produtos
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra agum erro retorna BadResquest e a mesnagem de erro
                return BadRequest(ex.Message);
            }
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {   //Buscar o produto no repositorio
                var produto = _produtoRepository.BuscarPorId(id);

                //Verificar se o produto existe
                //Caso produto não exista, retorna Notfound
                if (produto == null)
                    return NotFound();

                //Caso o prduto exista retornar
                //ok e os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna Bad Resquest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AlunoController>
        [HttpPost]
        public IActionResult Post(Produto produto)
        {
            try
            {
                //Adiciona um produto
                _produtoRepository.Adicionar(produto);

                //Retornar ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                //Caso ocorra um erro retorna Bad Resquest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }
        

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);
                if (produtoTemp == null)
                    return NotFound();


                produto.Id = id;
                _produtoRepository.Editar(produto); 


                return Ok(produto);

            }
            catch (Exception ex)
            {

                //Caso ocorra um erro retorna Bad Resquest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch (Exception ex)
            {

                //Caso ocorra um erro retorna Bad Resquest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }
    }
}

