using StockConferencia.Helpers;
using StockConferencia.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockConferencia.View
{
    public class ProdutosView
    {
        Exception error = new Exception();
        ProdutosHelpers produtosHelpers = new ProdutosHelpers();
        public void RenderProdutosView()
        {
            bool pause = true;

            while (pause)
            {
                try
                {

                    Console.Clear();
                    this.RenderOpcao();
                    error = new Exception("Erro ao inserir uma opcao");
                    int opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.Clear();
                            this.addProduto();
                            break;
                        case 2:
                            Console.Clear();
                            this.RenderListarProdutos();
                            break;
                        case 3:
                            Console.Clear();
                            this.RemoveProduto();
                            break;
                        case 4:
                            pause = false;
                            break;
                    }

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


        public void addProduto()
        {
            try
            {
                Console.WriteLine("Add produto");
                ProdutoModels produtonew = new ProdutoModels();

                error = new Exception("Erro ao digitar o nome");
                Console.Write("Nome: ");
                produtonew.ProdName = Console.ReadLine();

                if (produtonew.ProdName == "")
                {
                    throw new Exception("Erro ao digitar o nome");
                }

                error = new Exception("Erro ao digitar o ProdCod");
                Console.Write("ProdCod: ");
                produtonew.ProdCod = int.Parse(Console.ReadLine());

                error = new Exception("Erro ao digitar o ProdCod");
                Console.Write("ProdEan: ");
                produtonew.ProdEan = int.Parse(Console.ReadLine());

                produtosHelpers.AddProduto(produtonew);
            }
            catch (Exception e) { 
            
                Console.Clear();
                if (error.Message != null)
                {
                    Console.WriteLine(error.Message);
                }
                if (e.Message == null)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();
            }


        }

        public void RenderListarProdutos()
        {
            bool Pause = true;
            while (Pause)
            {
                Console.Clear();

                Console.WriteLine(@"Listar Produtos");

                Console.WriteLine(@"
            
            1 - Listar todos
            
            2 - Buscar por id

            3 - Buscar por Ean

            4 - Buscar por ProdCod
             
            5 - Sair

");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Listando todos os produtos");
                        foreach (var item in produtosHelpers.GetAll())
                        {
                            Console.WriteLine(item.ReturnProdutoToString());
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Digite id do produto: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Listando produto que contem o Id: " + id);
                        ProdutoModels p = produtosHelpers.GetId(id);
                        if (p != null)
                        {
                            Console.WriteLine(p.ReturnProdutoToString());
                        }
                        Console.ReadKey();
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        Pause = false;
                        break;
                }
            }
        }
        public void RemoveProduto()
        {
            try
            {
                Console.Write(@"Exclusao de Produto


Id: ");
                error = new Exception("Erro ao digitar o Id");
                int id = int.Parse(Console.ReadLine());

                produtosHelpers.DeleteProd(id);
            }
            catch (Exception e)
            {
                Console.Clear();
                if (error.Message != null)
                {
                    Console.WriteLine(error.Message);
                }
                if (e.Message == null)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Pressione qualquer tecla para continuar");
                Console.ReadKey();

            }


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
