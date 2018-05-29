using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Tripulantes
{
    public class Presidiario : Passageiro, ISubordinado
    {
        public List<Type> ObterSuperiores() => new List<Type> { typeof(Policial).GetType() };
    }
}
