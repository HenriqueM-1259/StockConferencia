using StockConferencia.Helpers;
using StockConferencia.Models;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StockConferencia.View
{
    public class ProdutosView
    {

        ProdutosHelpers produtosHelpers = new ProdutosHelpers();
        public void OpcoesView()
        {
            bool pause = true;

            while (pause)
            {
                Console.Clear();
                string ViewOpcoes = @"
-= -= -= -= Opcoes Produtos =- =- =- =-

            1 - Criar Produto
            
            2 - Listar Produtos

            3 - Excluir Produto

            4 - sair
            ";
                Console.WriteLine(ViewOpcoes);

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add produto");
                        ProdutoModels produtonew = new ProdutoModels();
                        Console.Write("Nome: ");
                        produtonew.ProdName = Console.ReadLine();
                        Console.Write("ProdCod: ");
                        produtonew.ProdCod = int.Parse(Console.ReadLine());
                        produtosHelpers.AddProduto(produtonew);
                        break;
                    case 2:
                        Console.Clear();
                        foreach (var item in produtosHelpers.GetAll())
                        {
                            Console.WriteLine(item.ReturnProdutoToString());
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        break;
                    case 4:
                        pause = false;
                        break;
                }
            }
            
        }
    }
}
