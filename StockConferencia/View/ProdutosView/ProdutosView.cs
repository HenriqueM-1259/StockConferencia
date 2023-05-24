using StockConferencia.Helpers;
using StockConferencia.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockConferencia.View.ProdutosView
{
    public class ProdutosView
    {
        Exception error = new Exception();
        ProdutosHelpers produtosHelpers = new ProdutosHelpers();
        bool pause = true;
        public void RenderizarProdutosView()
        {
            while (pause)
            {
                try
                {

                    Console.Clear();
                    RenderizaOpcoesProduto();

                }
                catch (Exception)
                {
                    Console.Clear();
                    if (error.Message != null)
                    {
                        Console.WriteLine(error.Message);
                    }
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                }

            }

        }

        public void RenderizaOpcoesProduto()
        {
            RenderOpcao();
            error = new Exception("Erro ao inserir uma opcao");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    addProduto();
                    break;
                case 2:
                    Console.Clear();
                    ProdutosAbasView AbasProdutoListagem = new ProdutosAbasView();
                    AbasProdutoListagem.RenderizarAbaListarProdutos(produtosHelpers);
                    break;
                case 3:
                    Console.Clear();
                    RemoveProduto();
                    break;
                case 4:
                    pause = false;
                    break;
            }

        }
        public void addProduto()
        {
           
                Console.WriteLine("Add produto");
                ProdutoModels ProdutoNovo = new ProdutoModels();

                error = new Exception("Erro ao digitar o nome");
                Console.Write("Nome: ");
                ProdutoNovo.ProdName = Console.ReadLine();

                if (ProdutoNovo.ProdName == "")
                {
                    throw new Exception("Erro ao digitar o nome");
                }

                error = new Exception("Erro ao digitar o ProdCod");
                Console.Write("ProdCod: ");
                ProdutoNovo.ProdCod = int.Parse(Console.ReadLine());

                error = new Exception("Erro ao digitar o ProdCod");
                Console.Write("ProdEan: ");
                ProdutoNovo.ProdEan = int.Parse(Console.ReadLine());

                produtosHelpers.AddProduto(ProdutoNovo);
          
        }

        public void RemoveProduto()
        {          
                Console.Write(@"Exclusao de Produto


Id: ");
                error = new Exception("Erro ao digitar o Id");
                int idProduto = int.Parse(Console.ReadLine()); 
                Console.Clear();
                Console.WriteLine(produtosHelpers.DeleteProd(idProduto));
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();          
        }
        public void RenderOpcao()
        {
            string ViewOpcoes = @"
-= -= -= -= Opcoes Produtos =- =- =- =-

            1 - Criar Produto
            
            2 - Listar Produtos

            3 - Excluir Produto

            4 - sair
            ";
            Console.WriteLine(ViewOpcoes);
        }
    }
}
