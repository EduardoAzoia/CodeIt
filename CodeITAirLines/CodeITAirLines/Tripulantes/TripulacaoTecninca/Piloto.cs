using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.TripulacaoTecninca
{
    public class Piloto : Motorista
    {
        public override List<Type> ObterNaoParceiros() => new List<Type> { typeof(Oficial) };
    }
}