using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes
{
    public class Presidiario : Passageiro
    {
        public override List<Type> ObterNaoParceiros() => ObterListaNaoParceiros();

        public override List<Type> ObterSuperior() => new List<Type> { typeof(Policial) };

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