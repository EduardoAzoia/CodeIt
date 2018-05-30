using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes
{
    public class Policial : Motorista
    {
        public override List<Type> ObterNaoParceiros() => new List<Type>();
    }
}