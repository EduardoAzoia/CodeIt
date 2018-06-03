using CodeITAirLines.Jogo;
using CodeITAirLines.Jogo.Interfaces;
using CodeITAirLines.Tripulantes.Interfaces;
using System.Collections.Generic;

namespace CodeITAirLines.Veiculo
{
    public class SmartForTwo : ISmartForTwo
    {
        public string Localizacao { get; set; }

        #region SMART_FOR_TWO

        public string SmartForTwoIndo { get { return SMART_FOR_TWO_INDO; } }

        private const string SMART_FOR_TWO_VOLTANDO = @"
                                                 ___
                                                /_| |
                                               [o_|o]=~";

        public string SmartForTwoVoltando { get { return SMART_FOR_TWO_VOLTANDO; } }

        private const string SMART_FOR_TWO_INDO = @"
    ___
   | |_\
 ~=[o|_o]";

        #endregion SMART_FOR_TWO

        private readonly IBuilderPassageiros builderPassageiros;
        private readonly IBuilderTexto builderTexto;
        private readonly IValidacoesTripulantes validacoesTripulantes;

        public SmartForTwo(IBuilderPassageiros builderPassageiros,
                                 IBuilderTexto builderTexto,
                        IValidacoesTripulantes validacoesTripulantes)
        {
            this.builderPassageiros = builderPassageiros;
            this.builderTexto = builderTexto;
            this.validacoesTripulantes = validacoesTripulantes;

            Localizacao = BibliotecaLocalizacao.AEROPORTO;
        }

        public void TrafegarPassageiros(List<string> caracteres)
        {
            var mensagem = string.Empty;

            var passageiros = new List<Passageiro>();

            caracteres.ForEach(x => passageiros.Add(builderPassageiros.ObterPassageiro(x)));

            if (!validacoesTripulantes.PassageirosProximosAoVeiculo(passageiros, Localizacao, out mensagem))
            {
                builderTexto.LancarMensagemDeAtencao(mensagem, Biblioteca.ATENCAO);
                return;
            }

            var saoDoisPassageiros = passageiros.Count > 1;

            mensagem = saoDoisPassageiros ? validacoesTripulantes.ValidarTripulantes(passageiros) : validacoesTripulantes.ValidarTripulante(passageiros);

            if (!string.IsNullOrWhiteSpace(mensagem))
            {
                builderTexto.LancarMensagemDeAtencao(mensagem, Biblioteca.VIOLACAO);
                return;
            }

            AlterarAtributos(passageiros);
        }

        private void AlterarAtributos(List<Passageiro> passageiros)
        {
            Localizacao = Localizacao.Equals(BibliotecaLocalizacao.AEROPORTO) ? BibliotecaLocalizacao.AVIAO : BibliotecaLocalizacao.AEROPORTO;
            passageiros.ForEach(x => x.Localizacao = Localizacao);
            var mensagem = string.Empty;

            if (!validacoesTripulantes.ValidarHierarquias(builderPassageiros.ListaPassageiros, out mensagem))
            {
                builderTexto.LancarMensagemDeAtencao(mensagem, Biblioteca.VIOLACAO);
                AlterarAtributos(passageiros);
            }
        }
    }
}