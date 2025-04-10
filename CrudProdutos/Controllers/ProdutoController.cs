using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace CrudProdutos.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(AppDbContext context, ILogger<ProdutoController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetListaProduto()
        {
            _logger.LogInformation("Listagem de todos produtos.");
            return await _context.Produto.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Produto>> GetProduto(int Id)
        {
            var produtos = await _context.Produto.FindAsync(Id);

            if (produtos == null)
            {
                return NotFound("O produto informado não existe no sistema.");
            }

            return produtos;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto([FromBody] Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Não foi possível inserir o produto no sistema.");
            }

            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduto), new { produto.Id }, produto);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<Produto>> PutProduto(int Id, [FromBody] Produto produto)
        {
            if (produto.Id != Id)
            {
                return BadRequest("O produto informado não é o mesmo do sistema.");
            }

            var produtos = await _context.Produto.FindAsync(Id);

            if (produtos == null)
            {
                return NotFound("O produto não foi encontrado.");
            }

            produtos.Titulo = produto.Titulo;
            produtos.Descricao = produto.Descricao;
            produtos.Preco = produto.Preco;
            produtos.Estoque = produto.Estoque;

            if (!string.IsNullOrEmpty(produto.Fotos))
            {
                produtos.Fotos = produto.Fotos;
            }

            await _context.SaveChangesAsync();
            return Ok(produtos);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int Id)
        {
            var produtos = await _context.Produto.FindAsync(Id);

            if (produtos == null)
            {
                return NotFound("O produto informado não existe no sistema.");
            }

            _context.Produto.Remove(produtos);
            await _context.SaveChangesAsync();
            return Ok("O produto foi removido com sucesso.");
        }
    }
}