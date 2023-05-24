using StockConferencia.View;
using StockConferencia.View.LotesViews;
using StockConferencia.View.ProdutosView;

namespace StockConferencia
{
    public class Menu
    {
        private Exception error = new Exception();
        private ProdutosView produtosView = new ProdutosView();
        private LotesView lotesView = new LotesView();
        private bool sair = true;
        private int opcao;
        public void RenderizarMenu()
        {
            while (sair)
            {
                try
                {
                    Console.Clear();
                    this.RenderizarOpcoesMenu();
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
        public void RenderizarOpcoesMenu()
        {
            this.RenderOpcaoView();
            error = new Exception("Erro ao inserir uma opcao");
            opcao = int.Parse(Console.ReadLine());
            this.SelecionaProximaView();
        }
        public void RenderOpcaoView()
        {
            Console.WriteLine(@"
-= -= -= -=         Menu         =- =- =- =-

            1 - Lotes

            2 - Produtos
	
            3 - Adicionar Stock

            0 - sair
					");
        }
        public void SelecionaProximaView()
        {
            switch (opcao)
            {
                case 0:
                    sair = false;
                    break;
                case 1:
                    lotesView.RenderLotesView();
                    break;
                case 2:
                    produtosView.RenderizarProdutosView();
                    break;
                default:
                    break;
            }
        }
        
    }
}
