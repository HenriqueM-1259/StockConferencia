using StockConferencia.Models;
using StockConferencia.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.DbMemory
{
    public class DBContext
    {
       
     
        List<ProdutoModels> ProdutoDb = new List<ProdutoModels> {
                 new ProdutoModels { Id = 1, ProdEan = 1231231, ProdCod = 1233, ProdName = "Produto1" },
                 new ProdutoModels { Id = 2, ProdEan = 1234567, ProdCod = 1234, ProdName = "Produto2" },
                 new ProdutoModels { Id = 3, ProdEan = 7891011, ProdCod = 4567, ProdName = "Produto3" },
                 new ProdutoModels { Id = 4, ProdEan = 1213141, ProdCod = 8910, ProdName = "Produto4" },
            };

        List<LoteModels> LotesDb = new List<LoteModels> {
                new LoteModels{ Id = 1, LoteName = "Lote001",LoteCod = 100 ,LoteCreate = DateTime.Now, LoteFab = DateTime.Now, LoteVenc = DateTime.Now, LoteAtivo = true},
                new LoteModels{ Id = 2, LoteName = "Lote002",LoteCod = 101, LoteCreate = DateTime.Now, LoteFab = DateTime.Now, LoteVenc = DateTime.Now, LoteAtivo = true},
                new LoteModels{ Id = 3, LoteName = "Lote003", LoteCod = 102, LoteCreate = DateTime.Now, LoteFab = DateTime.Now, LoteVenc = DateTime.Now, LoteAtivo = true},
                new LoteModels{ Id = 4, LoteName = "Lote004", LoteCod = 103, LoteCreate = DateTime.Now, LoteFab = DateTime.Now, LoteVenc = DateTime.Now, LoteAtivo = true}
            };

        List<LotesProdutos> ProdutosLotesDb = new List<LotesProdutos> {
                new LotesProdutos{ Id = 1, LoteCod= 100,  ProdCod = 1233 },
                new LotesProdutos{ Id = 1, LoteCod= 101,  ProdCod = 1234 },
                new LotesProdutos{ Id = 1, LoteCod= 102,  ProdCod = 4567 },
                new LotesProdutos{ Id = 1, LoteCod= 103,  ProdCod = 8910 }
            };

        public List<ProdutoModels> returnAllProdutos()
        {
            return ProdutoDb;
        }

        public List<LoteModels> returnAllLotes()
        {
            return LotesDb;
        }

        public List<LotesProdutos> returnAllProdutosLotes()
        {
            List<LotesProdutos> lotesProdutos =  new List<LotesProdutos>();
            var result = from Produto in ProdutoDb
                         join produtoLote in ProdutosLotesDb on Produto.ProdCod equals produtoLote.ProdCod
                         join lote in LotesDb on produtoLote.LoteCod equals lote.LoteCod
                         select new
                         {
                            produtoLote.LoteCod,
                            produtoLote.ProdCod,
                            Lote = lote,
                            produto = Produto,

                         };
            foreach (var item in result)
            {
                lotesProdutos.Add(new LotesProdutos
                {
                    ProdCod = item.ProdCod,
                    LoteCod = item.LoteCod,
                    Lote = item.Lote, 
                    Produto = item.produto,

                });
            }

            return lotesProdutos;
        }
    }
}
