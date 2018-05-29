using CodeITAirLines.Aeroporto;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeITAirLines.Jogo
{
    public class Acoes
    {
        private readonly List<string> caracterPermitido;

        private const string FALHA = "F";

        #region PREFACIO_JOGO

        private const string PREFACIO_JOGO = @"

Opcões:
- Digite quem vai para o SmartForTwo, ex: 0;1;
- Digite 'R' para ler as regras novamente
- Digite 'X' para sair do jogo";

        #endregion PREFACIO_JOGO

        public Instrucoes instrucoes;
        private readonly BuilderTripulantes builderTripulantes;
        private readonly SmartForTwo smartForTwo;
        private readonly BuilderTexto builderTexto;


        public Acoes(Instrucoes instrucoes,
             BuilderTripulantes builderTripulantes,
                    SmartForTwo smartForTwo,
                   BuilderTexto builderTexto)
        {
            this.instrucoes = instrucoes;
            this.builderTripulantes = builderTripulantes;
            this.smartForTwo = smartForTwo;
            this.builderTexto = builderTexto;

            caracterPermitido = new List<string> { "R", "X" };
        }

        public void Jogar()
        {
            instrucoes.MostrarInstrucoes();

            var iniciarJogo = instrucoes.IniciarJogo();

            if (!iniciarJogo)
                return;

            bool fimDeJogo = true;

            while (fimDeJogo)
            {
                PrefacioJogo();
                ValidarLeituraDados();
                 
                fimDeJogo = false;
            }
        }

        private bool TomarAcao(string acao, List<char> passageiros = null)
        {
            switch (acao)
            {
                case "P":
                    break;
                case "R":
                    instrucoes.MostrarRegras();
                    break;
                case "X":
                    return true;
                case FALHA:
                    MessageBox.Show("Por favor, digita essa merda direito");
                    break;
            }

            return false;
        }
        
        private void ValidarLeituraDados()
        {
            var resposta = Console.ReadLine().ToCharArray().ToList();

            if (resposta.Exists(x => x == ';'))
                return;
            else if (resposta.Count == 1)
            {
                var frase = resposta.First().ToString().ToUpper();
                var ehCaracterPermitido = caracterPermitido.Exists(x => x.Equals(frase));

                frase = ehCaracterPermitido ? frase : FALHA;

                TomarAcao(frase);
            }
            else
                MessageBox.Show("Por favor, digita essa merda direito");
        }

        public void PrefacioJogo()
        {
            var passageiros = builderTripulantes.ObterPassageiros();

            var localizacaoAtual = builderTexto.LocalizarPassageiros(passageiros);
            localizacaoAtual += builderTexto.LocalizarSmartForTwo(smartForTwo);

            instrucoes.MostrarMensagem(string.Format("{0}{1}{2}", instrucoes.Cabecalho, localizacaoAtual, PREFACIO_JOGO));
        }
    }
}
