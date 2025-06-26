namespace ApiProdutos.DTOs
{
    public class CreateProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
