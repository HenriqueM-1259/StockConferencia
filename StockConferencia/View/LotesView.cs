using StockConferencia.Helpers;
using StockConferencia.Helpers.IHelpers;
using StockConferencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConferencia.View
{
    public class LotesView
    {
        Exception error = new Exception();
        LotesHelpres LotesHelp = new LotesHelpres();


        public void RenderLotesView()
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
                            this.addLote();
                            break;
                        case 2:
                            Console.Clear();
                            this.ListarLotes();
                            break;
                        case 3:
                            pause =  false;
                            break;
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void ListarLotes()
        {
            Console.Clear();
            Console.WriteLine("Listando todos os produtos");
            foreach (var item in LotesHelp.GetAll())
            {
                Console.WriteLine(item.ReturnLoteToString());
            }
            Console.ReadKey();
        }
        public void addLote()
        {
            try
            {
                Console.WriteLine("Add Lote");
                LoteModels lotesnew = new LoteModels();

                error = new Exception("Erro ao digitar o nome");
                Console.Write("Nome: ");
                lotesnew.LoteName = Console.ReadLine();

                if (lotesnew.LoteName == "")
                {
                    throw new Exception("Erro ao digitar o nome");
                }

                LotesHelp.AddLotes(lotesnew);
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
-= -= -= -= Opcoes Lotes =- =- =- =-

            1 - Criar Lotes
            
            2 - Listar Lotes

            3 - Excluir Lotes

            4 - sair
            ";
            Console.WriteLine(ViewOpcoes);
        }
    }
}
