using StockConferencia.DbMemory;
using StockConferencia.Helpers.IHelpers;
using StockConferencia.Models;

namespace StockConferencia.Helpers
{
    public class ProdutosHelpers : IProdutosHelpers
    {
        public List<ProdutoModels> ProdutosDb = new DBContext().returnAllProdutos();
        Exception error = new Exception();

        public List<ProdutoModels> GetAll()
        {
            return ProdutosDb;
        }

        public ProdutoModels GetId(int idProduto)
        {
            if (idProduto == null) { error = new Exception("Erro ao Inserir o Id"); return null; }

            ProdutoModels produto = ProdutosDb.Find(Produto => Produto.Id == idProduto);

            if (produto == null) { error = new Exception("Produto nao existe"); return null; }

            return produto;
        }

        public ProdutoModels AddProduto(ProdutoModels p)
        {
            if (p == null) { return null; }


            if (p.Id == null)
            {
                int CountId = ProdutosDb.Count();
                CountId += 1;
                p.Id = CountId;
            }

            ProdutosDb.Add(p);

            return new ProdutoModels
            {
                ProdEan = p.ProdEan,
                ProdName = p.ProdName,
            };
        }

        public string DeleteProd(int id)
        {
            try
            {
                if (id == null) { return null; }

                ProdutoModels p = GetId(id);

                if (p == null) { throw new Exception("Produto nao existe"); }
                ProdutosDb.Remove(p);

                return "Produto Excluido com exito";
            }
            catch (Exception e)
            {
               return e.Message;

            }
           

        }
    }
}
