using ApiProdutos.Interfaces;
using ApiProdutos.Models;

namespace ApiProdutos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Produto>> ListarProdutosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Produto?> BuscarPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Produto> CriarProdutoAsync(Produto produto)
        {
            // Exemplo de regra de negócio: preço não pode ser negativo
            if (produto.Preco < 0)
                throw new ArgumentException("O preço não pode ser negativo.");

            return await _repository.CreateAsync(produto);
        }

        public async Task<bool> AtualizarProdutoAsync(int id, Produto produtoAtualizado)
        {
            var produtoExistente = await _repository.GetByIdAsync(id);
            if (produtoExistente == null)
                return false;

            // Atualiza os campos necessários
            produtoExistente.Nome = produtoAtualizado.Nome;
            produtoExistente.Preco = produtoAtualizado.Preco;
            produtoExistente.Quantidade = produtoAtualizado.Quantidade;

            await _repository.UpdateAsync(produtoExistente);
            return true;
        }

        public async Task<bool> RemoverProdutoAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null)
                return false;

            await _repository.DeleteAsync(produto);
            return true;
        }
    }
}
