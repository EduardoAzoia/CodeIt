using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Tripulantes.TripulacaoTecninca
{
    public class Piloto : Motorista
    {
        public override List<Type> ObterSubordinados() => new List<Type> { typeof(Oficial).GetType() };
    }
}
