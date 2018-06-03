using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.TripulacaoTecninca
{
    public class Oficial : Passageiro
    {
        public override List<Type> ObterNaoParceiros() => new List<Type> { typeof(ChefeVoo), typeof(Presidiario) };

        public override List<Type> ObterSuperior() => new List<Type> { typeof(Piloto) };
    }
}