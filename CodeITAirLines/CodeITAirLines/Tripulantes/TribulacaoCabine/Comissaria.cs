using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Tripulantes.TribulacaoCabine
{
    public class Comissaria : Passageiro, ISubordinado
    {
        public List<Type> ObterSuperiores() => new List<Type> { typeof(ChefeVoo).GetType(), typeof(Policial).GetType() };
    }
}
