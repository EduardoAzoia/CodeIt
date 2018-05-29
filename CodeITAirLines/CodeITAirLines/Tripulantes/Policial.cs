using CodeITAirLines.Tripulantes.TribulacaoCabine;
using CodeITAirLines.Tripulantes.TripulacaoTecninca;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;

namespace CodeITAirLines.Tripulantes
{
    public class Policial : Motorista
    {
        public override List<Type> ObterSubordinados() => ListarSubordinados();

        private List<Type> ListarSubordinados()
        {
            return new List<Type>
            {
                typeof(Presidiario).GetType(),
                typeof(Oficial).GetType(),
                typeof(Comissaria).GetType()
            };
        }
    }
}