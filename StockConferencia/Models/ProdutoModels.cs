namespace StockConferencia.Models
{
    public class ProdutoModels
    {
        public int Id { get; set; }
        public long ProdEan { get; set; }
        public long ProdCod { get; set; }
        public string ProdName { get; set; }


        public string ReturnProdutoToString()
        {
            return $"ProdCod: {ProdCod}, ProdEan: {ProdEan}, ProdNome: {ProdName}";
        }
    }
}
