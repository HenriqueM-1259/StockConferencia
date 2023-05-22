using StockConferencia.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia
{
    public class Menu
    {
        ProdutosView produtosView = new ProdutosView();
        bool sair = true;
        int opcao;
        public void RenderMenu()
        {

            while (sair)
            {
                Console.Clear();

                Console.WriteLine(@"
-= -= -= -= O que deseja Fazer hoje =- =- =- =-

            2 - Produtos
	
            0 - sair
					");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        sair = false;

                        break;
                    case 1:

                        break;
                    case 2:
                        Console.Clear();
                        produtosView.OpcoesView();
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
