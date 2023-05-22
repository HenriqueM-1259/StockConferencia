using StockConferencia.Models;

namespace StockConferencia.Helpers.IHelpers
{
    public interface IProdutosHelpers
    {
        public List<ProdutoModels> GetAll();
        public ProdutoModels GetId(int id);
        public ProdutoModels AddProduto(ProdutoModels p);
        public string DeleteProd(int id);
    }
}
