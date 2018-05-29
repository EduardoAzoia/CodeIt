using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Veiculo
{
    public abstract class Motorista : Passageiro, IMotorista
    {
        public abstract List<Type> ObterSubordinados();
    }
}
