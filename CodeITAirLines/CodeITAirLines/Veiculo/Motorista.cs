using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Veiculo
{
    public abstract class Motorista : Passageiro
    {
        public Motorista()
        {
            Dirigir = true;
        }

        public override List<Type> ObterParceiros() => new List<Type>();

        public override List<Type> ObterSuperior() => new List<Type>();
    }
}
