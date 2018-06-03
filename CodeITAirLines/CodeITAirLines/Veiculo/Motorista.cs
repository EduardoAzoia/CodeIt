using System;
using System.Collections.Generic;

namespace CodeITAirLines.Veiculo
{
    public abstract class Motorista : Passageiro
    {
        public Motorista()
        {
            Dirigir = true;
        }

        public override List<Type> ObterSuperior() => new List<Type>();

        public override List<Type> ObterNaoParceiros() => new List<Type>();
    }
}