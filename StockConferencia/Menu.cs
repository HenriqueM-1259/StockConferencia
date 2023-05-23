using StockConferencia.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StockConferencia
{
    public class Menu
    {
        Exception error = new Exception();
        ProdutosView produtosView = new ProdutosView();
        LotesView lotesView = new LotesView();
        bool sair = true;
        int opcao;
        public void RenderMenu()
        {

            while (sair)
            {
                try
                {
                    Console.Clear();
                    this.RenderOpcao();
                    error = new Exception("Erro ao inserir uma opcao");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 0:
                            sair = false;

                            break;
                        case 1:
                            Console.Clear();
                            lotesView.RenderLotesView();
                            break;
                        case 2:
                            Console.Clear();
                            produtosView.RenderProdutosView();
                            break;
                        default:
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

        public void RenderOpcao()
        {
            Console.WriteLine(@"
-= -= -= -=         Menu         =- =- =- =-

            1 - Lotes

            2 - Produtos
	
            0 - sair
					");
        }
    }
}
