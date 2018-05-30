using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Tripulantes
{
    public class Presidiario : Passageiro
    {
        public override List<Type> ObterNaoParceiros() => ObterListaNaoParceiros();

        public override List<Type> ObterParceiros() => new List<Type> { typeof(Policial) };

        public override List<Type> ObterSuperior() => ObterParceiros();

        private List<Type> ObterListaNaoParceiros()
        {
            return new List<Type>
            {
                typeof(Piloto),
                typeof(Oficial),
                typeof(ChefeVoo),
                typeof(Comissaria)
            };
        }
    };
}
