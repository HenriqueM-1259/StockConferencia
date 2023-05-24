using StockConferencia.Helpers;
using StockConferencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.View.ProdutosView
{
    internal class ProdutosAbasView
    {
        Exception error = new Exception();
        ProdutosHelpers produtosHelpers = new ProdutosHelpers();
        bool pause = true;
        public void RenderizarAbaListarProdutos(ProdutosHelpers produtosHelpers)
        {
            this.produtosHelpers = produtosHelpers;
            while (pause)
            {
                Console.Clear();

                Console.WriteLine(@"Listar Produtos");
                RenderizarOpcoesAbaListaProduto();
                SelecionaOpcoesAbaListaProduto();
            }
        }
        public void ListarTodosProdutos()
        {
            Console.Clear();
            Console.WriteLine("Listando todos os produtos");
            foreach (var item in produtosHelpers.GetAll())
            {
                Console.WriteLine(item.ReturnProdutoToString());
            }
            Console.ReadKey();
        }
        public void ListarProdutoId()
        {
            Console.Clear();
            Console.Write("Digite id do produto: ");
            error = new Exception("Erro ao Pesquisar Id");
            int IdProduto = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Listando produto que contem o Id: " + IdProduto);
            ProdutoModels retornoProduto = produtosHelpers.GetId(IdProduto);

            if (retornoProduto != null)
            {
                Console.WriteLine(retornoProduto.ReturnProdutoToString());
            }
            Console.ReadKey();
        }
        public void SelecionaOpcoesAbaListaProduto()
        {
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    ListarTodosProdutos();
                    break;
                case 2:
                    ListarProdutoId();
                    break;
                case 3:
                    pause = false;
                    break;
            }
        }
        public void RenderizarOpcoesAbaListaProduto()
        {

            Console.WriteLine(@"
            
            1 - Listar todos
            
            2 - Buscar por id
             
            3 - Sair

                ");
        }
    }
}
