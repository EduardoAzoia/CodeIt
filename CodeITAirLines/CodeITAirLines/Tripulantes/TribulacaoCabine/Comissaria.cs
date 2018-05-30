using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.TribulacaoCabine
{
    public class Comissaria : Passageiro
    {
        public override List<Type> ObterNaoParceiros() => new List<Type> { typeof(Piloto), typeof(Presidiario) };

        public override List<Type> ObterParceiros() => new List<Type> { typeof(ChefeVoo), typeof(Policial) };

        public override List<Type> ObterSuperior() => new List<Type> { typeof(ChefeVoo) };
    }
}