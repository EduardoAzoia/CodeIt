﻿using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.TribulacaoCabine
{
    public class ChefeVoo : Motorista
    {
        public override List<Type> ObterSubordinados() => new List<Type> { typeof(Comissaria).GetType() };
    }
}