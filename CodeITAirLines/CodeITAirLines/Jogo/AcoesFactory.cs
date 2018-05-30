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
            var builderPassageiros = new BuilderPassageiros();
            var builderTexto = new BuilderTexto(builderPassageiros);
            var smartForTwo = new SmartForTwo(builderPassageiros, builderTexto, new Tripulantes.Validacoes());            

            return new Acoes(new Instrucoes(builderTexto),
                             builderPassageiros,
                             smartForTwo,
                             builderTexto,
                             new Validacoes());
        }
    }
}
