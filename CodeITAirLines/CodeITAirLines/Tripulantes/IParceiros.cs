using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes
{
    public interface IParceiros
    {
        List<Type> ObterSuperior();

        List<Type> ObterParceiros();

        List<Type> ObterNaoParceiros();
    }
}