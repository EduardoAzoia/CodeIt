using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes.Interfaces
{
    public interface IParceiros
    {
        List<Type> ObterSuperior();

        List<Type> ObterNaoParceiros();
    }
}