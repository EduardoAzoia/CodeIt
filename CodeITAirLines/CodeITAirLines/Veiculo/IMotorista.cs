using System;
using System.Collections.Generic;

namespace CodeITAirLines.Veiculo
{
    public interface IMotorista
    {
        bool Pilotar { get; }

        List<Type> ObterSubordinados();
    }
}