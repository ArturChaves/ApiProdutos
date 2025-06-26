using ApiProdutos.Models;

namespace ApiProdutos.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto?> GetByIdAsync(int id);
        Task<Produto> CreateAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}
