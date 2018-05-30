using CodeITAirLines.Aeroporto;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeITAirLines.Jogo
{
    public class Acoes
    {
        private readonly List<string> caractersPermitidosMenu;

        private const string FALHA = "FALHA";

        #region OPCOES

        private const string OPCOES = @"

Opcões:
- Digite quem vai para o SmartForTwo, ex: 0;1;
- Digite 'R' para ler as regras novamente
- Digite 'X' para sair do jogo";

        #endregion OPCOES

        private readonly Instrucoes instrucoes;
        private readonly BuilderPassageiros builderPassageiros;
        private readonly SmartForTwo smartForTwo;
        private readonly BuilderTexto builderTexto;
        private readonly Validacoes validacoes;

        public Acoes(Instrucoes instrucoes,
             BuilderPassageiros builderPassageiros,
                    SmartForTwo smartForTwo,
                   BuilderTexto builderTexto,
                     Validacoes validacoes)
        {
            this.instrucoes = instrucoes;
            this.builderPassageiros = builderPassageiros;
            this.smartForTwo = smartForTwo;
            this.builderTexto = builderTexto;
            this.validacoes = validacoes;

            caractersPermitidosMenu = new List<string> { "R", "X" };
        }

        public void Jogar()
        {
            instrucoes.MostrarInstrucoes();

            var iniciarJogo = instrucoes.IniciarJogo();

            if (!iniciarJogo)
                return;

            bool fimDeJogo = false;
            var passageirosSmartForTwo = new List<string>();
            builderPassageiros.MontarListaPassageiros();

            while (!fimDeJogo)
            {
                PrefacioJogo(builderPassageiros.ListaPassageiros);
                var acao = ValidarLeituraDados(out passageirosSmartForTwo);

                fimDeJogo = TomarAcao(acao, passageirosSmartForTwo);
            }

            PrefacioJogo(builderPassageiros.ListaPassageiros);
            Console.Read();
            instrucoes.FimDeJogo();
        }

        protected bool TomarAcao(string acao, List<string> passageiros)
        {
            switch (acao)
            {
                case "P":
                    smartForTwo.TrafegarPassageiros(passageiros);
                    return EhFimJogo(builderPassageiros.ListaPassageiros);

                case "R":
                    instrucoes.MostrarRegras();
                    break;

                case "X":
                    return true;

                case "FALHA":
                    builderTexto.LancarMensagemDeAtencao(string.Format("Digite uma das opções citadas abaixo:{0}", OPCOES), "Operação inválida");
                    break;
            }

            return false;
        }

        protected string ValidarLeituraDados(out List<string> passageiros)
        {
            passageiros = new List<string>();

            var resposta = Console.ReadLine().ToCharArray();

            if (resposta.ToList().Exists(x => x == ';'))
                return validacoes.ValidarDados(resposta, out passageiros);
            else if (resposta.Length == 1)
            {
                var frase = resposta.First().ToString().ToUpper();

                var ehCaracterPermitido = caractersPermitidosMenu.Exists(x => x.Equals(frase));

                if (validacoes.ListaIdTripulantes.Exists(x => x.Equals(frase)))
                {
                    passageiros.Add(frase);
                    frase = "P";
                    ehCaracterPermitido = true;
                }

                return ehCaracterPermitido ? frase : FALHA;
            }

            return FALHA;
        }

        protected void PrefacioJogo(List<Passageiro> tripulantes)
        {
            var localizacaoAtual = builderTexto.LocalizarPassageiros(tripulantes);
            localizacaoAtual += builderTexto.LocalizarSmartForTwo(smartForTwo);

            instrucoes.MostrarMensagem(string.Format("{0}{1}{2}", instrucoes.Cabecalho, localizacaoAtual, OPCOES));
        }

        protected bool EhFimJogo(List<Passageiro> passageiros)
        {
            if (!passageiros.Exists(x => x.Localizacao.Equals(Localizacoes.AEROPORTO)))
            {
                builderTexto.LancarMensagemInformativa("Parabéns, você conseguiu levar toda a tripulação em segurança!!!", "Parabéns");
                return true;
            }

            return false;
        }
    }
}