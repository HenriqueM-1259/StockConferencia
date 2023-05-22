using StockConferencia.Models;
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


        public List<ProdutoModels> returnAllProdutos()
        {
            return ProdutoDb;
        }
    }
}
