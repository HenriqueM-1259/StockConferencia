using StockConferencia.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.Models
{
    public class LotesProdutos
    {
        public int Id { get; set; }
        public int LoteCod { get; set; }
        public int ProdCod { get; set; }
        public int Quantidade { get; set; }

        public LoteModels Lote { get; set; } 
        public ProdutoModels Produto { get; set; }
        public string ReturnLoteProdutoToString()
        {
            return @$"lote: {Lote.ReturnLoteToString()} - " +
                $"Produto: {Produto.ReturnProdutoToString()}," +
                $"Quantidade:{Quantidade} ";
        }
    }
}
