using StockConferencia.DbMemory;
using StockConferencia.Helpers.IHelpers;
using StockConferencia.Models;

namespace StockConferencia.Helpers
{
    public class ProdutosHelpers : IProdutosHelpers
    {
        public List<ProdutoModels> ProdutosDb = new DBContext().returnAllProdutos();

        public List<ProdutoModels> GetAll()
        {
            return ProdutosDb;
        }

        public ProdutoModels GetId(int id)
        {
            if (id == null) { return null; }

            ProdutoModels p = ProdutosDb.Find(x => x.Id == id);

            if (p == null) { return null; }

            return p;
        }

        public ProdutoModels AddProduto(ProdutoModels p)
        {
            if (p == null) { return null; }

            ProdutosDb.Add(p);

            return new ProdutoModels
            {
                ProdEan = p.ProdEan,
                ProdName = p.ProdName,
            };
        }

        public string DeleteProd(int id)
        {

            if (id == null) { return null; }

            ProdutoModels p = GetId(id);
            ProdutosDb.Remove(p);

            return "Produto Excluido com exito";

        }
    }
}
