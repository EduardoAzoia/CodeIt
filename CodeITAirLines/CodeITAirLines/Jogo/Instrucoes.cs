using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeITAirLines.Jogo
{
    public class Instrucoes
    {
        #region CABECALHO

        public string Cabecalho { get { return CABECALHO; } }

        private const string CABECALHO = @"                                         ___________
                                              |
                                         _   _|_   _
                                        (_)-/   \-(_)
             _                             /\___/\                             _
            (_)___________________Bem vindo a CodeAirLines!___________________(_)
                                           \_____/";

        #endregion CABECALHO

        #region PREFACIO

        private const string PREFACIO = @"

Seu objetivo aqui é transportar uma tripulação de 8 pessoas que estão no aeroporto até um avião:

- Capitão (0);
- 1º Oficial (1);
- 2º Oficial (2);
- Chefe de Voo (3);
- 1ª Comissária de Bordo (4);
- 2ª Comissária de Bordo (5);
- Policial (6);
- Presidiário (7).";

        #endregion PREFACIO

        #region REGRAS

        private const string REGRAS = @"

Existem cinco regras para o transporte dos mesmos:

- 1ª O Capitão não pode ficar a sós com as Comissárias de Bordo;
- 2ª O Chefe de Voo não pode ficar a sós com os Oficiais;
- 3ª Apenas o Policial pode ficar a sós com o Presidiário;
- 4ª As pessoas só podem ser transportadas através de um SmartForTwo, com apens dois lugares (motorista e passageiro);
- 5ª Apenas o Capitão, Chefe de Voo e o Policial podem pilotar o SmartForTwo.

Como jogar:

- Digite a siglas daqueles que forem entrar no veículo, como no exemplo abaixo
  Ex: 0;1 - 0 para o Capitão e 1 para 1º Oficiail";

        #endregion REGRAS

        private const string INICIAR_JOGO = "\nPara iniciar o jogo aperte a tecla 'S' para continuar 'N' para finalizar o jogo!";

        #region FIM_DE_JOGO

        private const string FIM_DE_JOGO = @"

                                \ /                       \ /
                           x----oOo----x FIM DE JOGO x----oOo----x";

        #endregion FIM_DE_JOGO

        public void MostrarInstrucoes()
        {
            MostrarMensagem(string.Format("{0}{1}", CABECALHO, PREFACIO));
            MostrarMensagem(string.Format("{0}{1}", CABECALHO, REGRAS));
        }

        public void MostrarRegras()
        {
            MessageBox.Show(string.Format("{0}{1}", PREFACIO, REGRAS));
        }
         
        public bool IniciarJogo()
        {
            Console.WriteLine(INICIAR_JOGO);

            var resposta = LerResposta(new List<string> { "S", "N" });

            return resposta.Equals("S");
        }

        public void FimDeJogo()
        {
            MostrarMensagem(string.Format("{0}{1}", CABECALHO, FIM_DE_JOGO));
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.Clear();
            Console.WriteLine(mensagem);
            Console.Read();
        }

        public string LerResposta(List<String> caracteres)
        {
            var existeNaLista = false;
            var resposta = string.Empty;

            while (!existeNaLista)
            {
                resposta = Console.ReadKey().Key.ToString().ToUpper();
                existeNaLista = caracteres.Exists(caracter => caracter.Equals(resposta));
            }

            return resposta;
        }
    }
}
