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

        private const string FALHA = "FALHA";

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
        private readonly Validacoes validacoes;


        public Acoes(Instrucoes instrucoes,
             BuilderTripulantes builderTripulantes,
                    SmartForTwo smartForTwo,
                   BuilderTexto builderTexto,
                     Validacoes validacoes)
        {
            this.instrucoes = instrucoes;
            this.builderTripulantes = builderTripulantes;
            this.smartForTwo = smartForTwo;
            this.builderTexto = builderTexto;
            this.validacoes = validacoes;

            caracterPermitido = new List<string> { "R", "X" };
        }

        public void Jogar()
        {
            instrucoes.MostrarInstrucoes();

            var iniciarJogo = instrucoes.IniciarJogo();

            if (!iniciarJogo)
                return;

            bool fimDeJogo = false;
            var passageiros = new List<string>();

            while (!fimDeJogo)
            {
                PrefacioJogo();
                var acao = ValidarLeituraDados(out passageiros);
                
                fimDeJogo = TomarAcao(acao, passageiros);
            }
        }

        private bool TomarAcao(string acao, List<string> passageiros)
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
                case "FALHA":
                    MessageBox.Show("Operação inválida!\nSe ainda possuir dúvidas acesse o menu de regras.");
                    break;
            }

            return false;
        }
        
        private string ValidarLeituraDados(out List<string> passageiros)
        {
            passageiros = new List<string>();

            var resposta = Console.ReadLine().ToCharArray();

            if (resposta.ToList().Exists(x => x == ';'))
                validacoes.ValidarDados(resposta, out passageiros);

            else if (resposta.Length == 1)
            {
                var frase = resposta.First().ToString().ToUpper();
                var ehCaracterPermitido = caracterPermitido.Exists(x => x.Equals(frase));

                return ehCaracterPermitido ? frase : FALHA;
            }

            return FALHA;
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
