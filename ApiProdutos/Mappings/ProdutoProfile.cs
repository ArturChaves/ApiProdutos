using ApiProdutos.DTOs;
using ApiProdutos.Models;
using AutoMapper;

namespace ApiProdutos.Mappings
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            // De Produto -> ProdutoDto
            CreateMap<Produto, ProdutoDto>();

            // De CreateProdutoDto -> Produto
            CreateMap<CreateProdutoDto, Produto>();

            // De UpdateProdutoDto -> Produto
            CreateMap<UpdateProdutoDto, Produto>();
        }
    }
}
