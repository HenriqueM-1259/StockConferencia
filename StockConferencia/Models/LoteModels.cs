using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.Models
{
    public class LoteModels
    {
        public int Id { get; set; }
        public int LoteCod { get; set; }
        public string LoteName { get; set; }
        public DateTime LoteCreate { get; set; }
        public DateTime LoteFab { get; set; }
        public DateTime LoteVenc { get; set; }
        public bool LoteAtivo { get; set; }


        public string ReturnLoteToString()
        {
            return $"LoteName: {LoteName}, LoteFab: {LoteFab}, LoteAtivo: {LoteAtivo}";
        }
    }
}
