using CodeITAirLines.Aeroporto;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Jogo
{
    public class BuilderTexto
    {
        #region FORMATACAO

        private const string FORMATACAO = "\n{0}                                     {1}";
        private const string FORMATACAO_CABECALHO = "\n\n{0}                                     {1}\n";

        #endregion FORMATACAO

        private readonly DicionarioPassageiros dicionarioPassageiros;

        public BuilderTexto(DicionarioPassageiros dicionarioPassageiros)
        {
            this.dicionarioPassageiros = dicionarioPassageiros;
        }

        public string LocalizarPassageiros(Dictionary<int, Passageiro> passageiros)
        {
            var situacaoAtual = string.Format(FORMATACAO_CABECALHO, Localizacoes.AEROPORTO, Localizacoes.AVIAO);

            passageiros.ToList().ForEach(x =>
            {
                var EhAeroporto = x.Value.Localizacao == Localizacoes.AEROPORTO;
                situacaoAtual += MontarFrase(EhAeroporto, dicionarioPassageiros.ObterNomes()[x.Key]);
            });

            return situacaoAtual;
        }

        public string LocalizarSmartForTwo(SmartForTwo smartForTwo)
        {
            var ehAeroporto = smartForTwo.Localizacao == Localizacoes.AEROPORTO;
            var situacaoSmartForTwo = ehAeroporto ? smartForTwo.SmartForTwoIndo : smartForTwo.SmartForTwoVoltando;
            return MontarFrase(ehAeroporto, situacaoSmartForTwo);
        }

        private string MontarFrase(bool ehAeroporto, string nome)
        {
            return ehAeroporto ?
                string.Format(FORMATACAO, nome, string.Empty) :
                string.Format(FORMATACAO, new string(' ', 9), nome);
        }
    }
}
