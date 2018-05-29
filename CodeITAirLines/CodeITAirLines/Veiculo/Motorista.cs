using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Veiculo
{
    public abstract class Motorista : Passageiro, IMotorista
    {
        bool IMotorista.Pilotar => true;

        public abstract List<Type> ObterSubordinados();
    }
}
