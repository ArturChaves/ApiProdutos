namespace ApiProdutos.DTOs
{
    public class UpdateProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
