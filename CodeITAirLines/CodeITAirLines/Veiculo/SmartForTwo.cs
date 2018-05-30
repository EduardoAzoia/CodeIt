using CodeITAirLines.Aeroporto;
using CodeITAirLines.Jogo;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Veiculo
{
    public class SmartForTwo
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

        private const string VIOLACAO = "Violação das regras da empresa";

        private readonly BuilderPassageiros builderPassageiros;
        private readonly BuilderTexto builderTexto;
        private readonly Tripulantes.Validacoes validacoes;

        public SmartForTwo(BuilderPassageiros builderPassageiros,
                                 BuilderTexto builderTexto,
                       Tripulantes.Validacoes validacoes)
        {
            this.builderPassageiros = builderPassageiros;
            this.builderTexto = builderTexto;
            this.validacoes = validacoes;

            Localizacao = Localizacoes.AEROPORTO;
        }

        public void TrafegarPassageiros(List<string> caracteres)
        {
            var mensagem = string.Empty;

            List<Passageiro> passageiros = new List<Passageiro>();

            caracteres.ForEach(x => passageiros.Add(builderPassageiros.ObterPassageiro(x)));

            if (!validacoes.PassageirosProximosAoVeiculo(passageiros, Localizacao, out mensagem))
            {
                builderTexto.LancarMensagemDeAtencao(mensagem, "Atenção");
                return;
            }

            if (passageiros.Exists(x => x.Dirigir != true))
                mensagem = passageiros.Count > 1 ? validacoes.ValidarTripulantes(passageiros) : validacoes.ValidarTripulante(passageiros);

            if (!string.IsNullOrWhiteSpace(mensagem))
            {
                builderTexto.LancarMensagemDeAtencao(mensagem, VIOLACAO);
                return;
            }

            AlterarAtributos(passageiros);
        }

        private void AlterarAtributos(List<Passageiro> passageiros)
        {
            Localizacao = Localizacao.Equals(Localizacoes.AEROPORTO) ? Localizacoes.AVIAO : Localizacoes.AEROPORTO;
            passageiros.ForEach(x => x.Localizacao = Localizacao);
            var mensagem = string.Empty;

            if (!validacoes.ValidarHierarquias(builderPassageiros.ListaPassageiros, out mensagem))
            {
                builderTexto.LancarMensagemDeAtencao(mensagem, VIOLACAO);
                AlterarAtributos(passageiros);
            }
        }
    }
}
