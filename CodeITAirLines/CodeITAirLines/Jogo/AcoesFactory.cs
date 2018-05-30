using CodeITAirLines.Aeroporto;
using CodeITAirLines.Tripulantes;
using CodeITAirLines.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeITAirLines.Jogo
{
    public class AcoesFactory
    {
        public Acoes Obter()
        {
            var builderTripulantes = new BuilderTripulantes();
            return new Acoes(new Instrucoes(),
                             builderTripulantes,
                             new SmartForTwo(),
                             new BuilderTexto(builderTripulantes),
                             new Validacoes());
        }
    }
}
