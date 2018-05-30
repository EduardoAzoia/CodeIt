using CodeITAirLines.Jogo.Interfaces;
using CodeITAirLines.Tripulantes.Interfaces;
using CodeITAirLines.Veiculo;
using System.Collections.Generic;

namespace CodeITAirLines.Jogo
{
    public class Acoes : IAcoes
    {
        private readonly IInstrucoes instrucoes;
        private readonly IBuilderPassageiros builderPassageiros;
        private readonly ISmartForTwo smartForTwo;
        private readonly IBuilderTexto builderTexto;
        private readonly IValidacoesDados validacoesDados;

        public Acoes(IInstrucoes instrucoes,
             IBuilderPassageiros builderPassageiros,
                    ISmartForTwo smartForTwo,
                   IBuilderTexto builderTexto,
                IValidacoesDados validacoesDados)
        {
            this.instrucoes = instrucoes;
            this.builderPassageiros = builderPassageiros;
            this.smartForTwo = smartForTwo;
            this.builderTexto = builderTexto;
            this.validacoesDados = validacoesDados;
        }

        public void Jogar()
        {
            instrucoes.MostrarInstrucoes();

            var iniciarJogo = instrucoes.IniciarJogo();

            if (!iniciarJogo)
            {
                instrucoes.FimDeJogo();
                return;
            }

            bool fimDeJogo = false;
            var passageirosSmartForTwo = new List<string>();
            builderPassageiros.MontarListaPassageiros();

            while (!fimDeJogo)
            {
                instrucoes.PrefacioJogo(builderPassageiros.ListaPassageiros, smartForTwo);
                var acao = validacoesDados.ValdarDadosRecebidos(out passageirosSmartForTwo);

                fimDeJogo = ExecutarOpcoes(acao, passageirosSmartForTwo);
            }

            instrucoes.FimDeJogo();
        }

        protected bool ExecutarOpcoes(string acao, List<string> passageiros)
        {
            switch (acao)
            {
                case Biblioteca.INICIAR_TRANSPORTE:
                    smartForTwo.TrafegarPassageiros(passageiros);
                    return EhFimJogo(builderPassageiros.ListaPassageiros);

                case Biblioteca.MOSTRAR_REGRAS:
                    instrucoes.MostrarRegras();
                    break;

                case Biblioteca.SAIR:
                    return true;

                case Biblioteca.FALHA:
                    builderTexto.LancarMensagemDeAtencao(string.Format("{0},{1}", Biblioteca.UMA_DAS_OPCOES, Biblioteca.OPCOES), Biblioteca.OPERACAO_INVALIDA);
                    break;
            }

            return false;
        }

        protected bool EhFimJogo(List<Passageiro> passageiros)
        {
            if (!passageiros.Exists(x => x.Localizacao.Equals(BibliotecaLocalizacao.AEROPORTO)))
            {
                builderTexto.LancarMensagemInformativa(Biblioteca.PARABENIZAR, Biblioteca.PARABENS);
                return true;
            }

            return false;
        }
    }
}