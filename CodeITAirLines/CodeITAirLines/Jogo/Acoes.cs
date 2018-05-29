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
        #region PREFACIO_JOGO

        private const string PREFACIO_JOGO = @"

Opcões:
- Digite quem vai para o SmartForTwo, ex: 0;1;
- Digite 'R' para ler as regras novamente
- Digite 'X' para sair do jogo";

        #endregion PREFACIO_JOGO

        public Instrucoes instrucoes;
        private readonly DicionarioPassageiros dicionarioPassageiros;
        private readonly SmartForTwo smartForTwo;
        private readonly BuilderTexto builderTexto;


        public Acoes(Instrucoes instrucoes,
          DicionarioPassageiros dicionarioPassageiros,
                    SmartForTwo smartForTwo,
                   BuilderTexto builderTexto)
        {
            this.instrucoes = instrucoes;
            this.dicionarioPassageiros = dicionarioPassageiros;
            this.smartForTwo = smartForTwo;
            this.builderTexto = builderTexto;
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

        private void TomarAcao(string acao, List<char> passageiros = null)
        {
            switch (acao)
            {
                case "P":
                    break;
                case "R":
                    break;
                case "X":
                    break;
            }
        }
        
        private void ValidarLeituraDados()
        {
            var resposta = Console.ReadLine().ToCharArray().ToList();

            if (resposta.Exists(x => x == ';'))
                return;
            else if (resposta.Count == 1)
                return;
            else
                MessageBox.Show("Por favor, digita essa merda direito");
        }

        public void PrefacioJogo()
        {
            var passageiros = dicionarioPassageiros.ObterPassageiros();

            var localizacaoAtual = builderTexto.LocalizarPassageiros(passageiros);
            localizacaoAtual += builderTexto.LocalizarSmartForTwo(smartForTwo);

            instrucoes.MostrarMensagem(string.Format("{0}{1}{2}", instrucoes.Cabecalho, localizacaoAtual, PREFACIO_JOGO));
        }
    }
}
