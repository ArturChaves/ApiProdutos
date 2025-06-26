using ApiProdutos.DTOs;
using ApiProdutos.Interfaces;
using ApiProdutos.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetTodos()
        {
            var produtos = await _produtoService.ListarProdutosAsync();
            var produtosDto = _mapper.Map<IEnumerable<ProdutoDto>>(produtos);
            return Ok(produtosDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDto>> GetPorId(int id)
        {
            var produto = await _produtoService.BuscarPorIdAsync(id);
            if (produto == null)
                return NotFound();

            return Ok(_mapper.Map<ProdutoDto>(produto));
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> Criar([FromBody] CreateProdutoDto dto)
        {
            var produto = _mapper.Map<Produto>(dto);

            try
            {
                var criado = await _produtoService.CriarProdutoAsync(produto);
                return CreatedAtAction(nameof(GetPorId), new { id = criado.Id }, _mapper.Map<ProdutoDto>(criado));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UpdateProdutoDto dto)
        {
            var produto = _mapper.Map<Produto>(dto);

            var sucesso = await _produtoService.AtualizarProdutoAsync(id, produto);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var sucesso = await _produtoService.RemoverProdutoAsync(id);
            if (!sucesso)
                return NotFound();

            return NoContent();
        }
    }
}
