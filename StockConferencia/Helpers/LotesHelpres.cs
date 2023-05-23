using StockConferencia.DbMemory;
using StockConferencia.Helpers.IHelpers;
using StockConferencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.Helpers
{
    public class LotesHelpres: ILotesHelpers
    {
        public List<LoteModels> LotesDb = new DBContext().returnAllLotes();
        public List<LotesProdutos> ProdutosLotesDb = new DBContext().returnAllProdutosLotes();

        public List<LoteModels> GetAll()
        {
            return LotesDb;
        }
        public List<LotesProdutos> LotesProdutos()
        {
            return ProdutosLotesDb;
        }
        public LoteModels GetId(int id)
        {
            if (id == null) { return null; }

            LoteModels p = LotesDb.Find(x => x.Id == id);

            if (p == null) { return null; }

            return p;
        }

        public LoteModels AddLotes(LoteModels l)
        {
            if (l == null) { return null; }


            if (l.Id == null)
            {
                int CountId = LotesDb.Count();
                CountId += 1;
                l.Id = CountId;
            }
            l.LoteVenc = DateTime.Now;
            l.LoteCreate = DateTime.Now;
            l.LoteFab = DateTime.Now;

            LotesDb.Add(l);

            return new LoteModels
            {
                LoteName = l.LoteName,
                 LoteAtivo = l.LoteAtivo,
            };
        }

        public string DeleteProd(int id)
        {
            try
            {
                if (id == null) { return null; }

                LoteModels p = GetId(id);

                if (p == null) { throw new Exception("Produto nao existe"); }
                LotesDb.Remove(p);

                return "Produto Excluido com exito";
            }
            catch (Exception e)
            {
                return e.Message;

            }


        }
    }
}
