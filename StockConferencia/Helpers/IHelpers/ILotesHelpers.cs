using StockConferencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.Helpers.IHelpers
{
    public interface ILotesHelpers
    {
        public List<LoteModels> GetAll();
        public LoteModels GetId(int id);
        public LoteModels AddLotes(LoteModels p);
        public string DeleteProd(int id);
        public List<LotesProdutos> LotesProdutos();
    }
}
