using ApiProdutos.Models;

namespace ApiProdutos.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListarProdutosAsync();
        Task<Produto?> BuscarPorIdAsync(int id);
        Task<Produto> CriarProdutoAsync(Produto produto);
        Task<bool> AtualizarProdutoAsync(int id, Produto produtoAtualizado);
        Task<bool> RemoverProdutoAsync(int id);
    }
}
