using CodeITAirLines.Aeroporto;
using CodeITAirLines.Tripulantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Veiculo
{
    public abstract class Passageiro : IParceiros
    {
        public bool Dirigir { get; set; }
        public string Localizacao { get; set; }
        public string Nome { get; set; }

        public Passageiro()
        {
            Localizacao = Localizacoes.AEROPORTO;
        }

        public abstract List<Type> ObterParceiros();
        public abstract List<Type> ObterNaoParceiros();
        public abstract List<Type> ObterSuperior();
    }
}
