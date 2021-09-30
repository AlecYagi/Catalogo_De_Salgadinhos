using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Catalogo_De_Salgadinhos.Exceptions;
using Catalogo_De_Salgadinhos.InputModel;
using Catalogo_De_Salgadinhos.Services;
using Catalogo_De_Salgadinhos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo_De_Salgadinhos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var produto = await _produtoService.Obter(pagina, quantidade );
            if (produto.Count() == 0)
                return NoContent();
            return Ok(produto);
        }

        [HttpGet("{idProduto:guid}")]

        public async Task<ActionResult<ProdutoViewModel>> Obter([FromRoute] Guid idProduto)
        {
            var produto = await _produtoService.Obter(idProduto);

            if (produto == null)
                return NoContent();

            return Ok(produto);
        }

        [HttpPost]

        public async Task<ActionResult<ProdutoViewModel>> InserirProduto([FromBody] ProdutoInputModel produtoInputModel)
        {
            try
            {
                var produto = await _produtoService.Inserir(produtoInputModel);

                return Ok(produto);
            }
            catch (ProdutoJaCadastradoException ex)
            {
                return UnprocessableEntity("Já existe um salgadinho com este nome para esta marca");
            }
        }

        [HttpPut("{idProduto:guid}")]

        public async Task<ActionResult> AtualizarProduto([FromRoute] Guid idProduto, [FromBody] ProdutoInputModel produtoInputModel)
        {
            try
            {
                await _produtoService.Atualizar(idProduto, produtoInputModel);

                return Ok();
            }
            catch (ProdutoNaoCadastradoException ex)
            {
                return NotFound("Não existe este Salgadinho");
            }
        }

        [HttpPatch("{idProduto:guid})/preco/{preco:double}")]

        public async Task<ActionResult> AtualizarProduto([FromRoute] Guid idProduto, [FromRoute] double preco)
        {
            try
            {
                await _produtoService.Atualizar(idProduto, preco);

                return Ok();
            }
            catch (ProdutoNaoCadastradoException ex)
            {
                return NotFound("Não existe este Salgadinho");
            }
        }

        [HttpDelete("{idProduto:guid}")]

        public async Task<ActionResult> ApagarProduto([FromRoute] Guid idProduto)
        {
            try
            {
                await _produtoService.Remover(idProduto);

                return Ok();
            }
            catch (ProdutoNaoCadastradoException ex)
            {
                return NotFound("Não existe este Salgadinho");
            }
        }

    }
}